using Asat.Tools;
using System;
using System.Collections.Generic;
using System.Reflection;
using Asat.Framework.Event;

namespace Asat.Framework
{
    public class Engine : Event.EventListener
    {
        private int m_iNextApiContextUid;
        private int m_iNextModuleUid;
        private EngineConfig m_engineConfig;
        private Event.EventManager m_eventManager;
        private EngineEvents m_engineEvents;
        private List<Module> m_modules;
        private SortedDictionary<int, ApiContext> m_apiContexts;
        private int m_iModuleAvailableEventUid;
        private int m_iModuleUnavailableEventUid;
        private int m_iApiConstructedEventUid;
        private int m_iDependencyRequestEventUid;

        public Engine(EngineConfig config)
        {
            m_engineConfig = ResolveEngineConfig(config);
            m_eventManager = new Event.EventManager();
            m_engineEvents = new EngineEvents(m_eventManager);
            m_modules = new List<Module>();
            m_apiContexts = new SortedDictionary<int, ApiContext>();
            m_iNextApiContextUid = 0;
            m_iNextModuleUid = 0;

            m_iModuleAvailableEventUid = m_engineEvents.GetEventTypeUid(EngineEvents.Types.MODULE_AVAILABLE);
            m_iModuleUnavailableEventUid = m_engineEvents.GetEventTypeUid(EngineEvents.Types.MODULE_UNAVAILABLE);
            m_iApiConstructedEventUid = m_engineEvents.GetEventTypeUid(EngineEvents.Types.API_CONSTRUCTED);
            m_iDependencyRequestEventUid = m_engineEvents.GetEventTypeUid(EngineEvents.Types.DEPENDENCY_REQUEST);

            m_eventManager.AddEventListener(this, m_engineEvents.GetEventTypeUid(EngineEvents.Types.DEPENDENCY_REQUEST));

            AddModule<Modules.Database.DatabaseModule>("database", null);
            AddModule<Modules.Disk.DiskModule>("disk", null);
            AddModule<Modules.Network.NetworkModule>("network", null);
            AddModule<Modules.Validation.ValidationModule>("validation", null);
            AddModule<Modules.Settings.SettingsModule>("settings", new List<string> { "database", "database" } );
        }

        private EngineConfig ResolveEngineConfig(EngineConfig config)
        {
            if (config == null)
            {
                config = new EngineConfig(Assembly.GetCallingAssembly().FullName);
            }

            return config;
        }

        /// <summary>
        /// Gets a list of all currently active module names.
        /// </summary>
        /// <returns>A list of </returns>
        public List<string> GetActiveModuleNames()
        {
            // Currently just returning all names - this may change in the future, hence the two separate functions
            return GetModuleNames();
        }

        /// <summary>
        /// Gets a list of all module names.
        /// </summary>
        /// <returns>A list of </returns>
        public List<string> GetModuleNames()
        {
            List<string> names = new List<string>();
            foreach (Module module in m_modules)
            {
                names.Add(module.GetName());
            }
            return names;
        }

        /// <summary>
        /// Adds a module of the given type. Modules must have unique names. Modules must provide a public
        /// constructor that takes a ModuleConfig and at most one other parameter (see overloads).
        /// </summary>
        /// <typeparam name="ModuleType">The type of module to create. Must inherit from Framework.Module</typeparam>
        /// <param name="sName">The name by which to refer to the module</param>
        /// <param name="dependencies">A list of module names that this module requires access to</param>
        /// <returns>True if the module was successfully added, false otherwise</returns>
        /// <exception cref="ModuleException">Thrown when no valid module constructor could be found</throws>
        public bool AddModule<ModuleType>(string sName, List<string> dependencies) where ModuleType : Module
        {
            return AddModule<ModuleType, object>(null, sName, dependencies);
        }

        /// <summary>
        /// Adds a module of the given type. Modules must have unique names. Modules must provide a public
        /// constructor that takes a ModuleConfig and at most one other parameter whose type must be specified
        /// as the second type parameter to this function.
        /// </summary>
        /// <typeparam name="ModuleType">The type of module to create. Must inherit from Framework.Module</typeparam>
        /// <typeparam name="ConfigType">The type of configuration object to forward to the module constructor</typeparam>
        /// <param name="sName">The name by which to refer to the module</param>
        /// <param name="dependencies">A list of module names that this module requires access to</param>
        /// <returns>True if the module was successfully added, false otherwise</returns>
        /// <exception cref="ModuleException">Thrown when no valid module constructor could be found</throws>
        public bool AddModule<ModuleType, ConfigType>(ConfigType config, string sName, List<string> dependencies) where ModuleType : Module
        {
            if (string.IsNullOrEmpty(sName))
            {
                return false;
            }

            // Dont allow modules to specify themselves as dependencies. Also filter out duplicates and
            // invalid values.
            if (dependencies == null)
            {
                dependencies = new List<string>();
            }

            dependencies.Remove(sName);
            SortedSet<string> dependencyFilter = new SortedSet<string>();
            foreach (string sDependencyName in dependencies)
            {
                if (!string.IsNullOrWhiteSpace(sDependencyName))
                {
                    dependencyFilter.Add(sDependencyName);
                }
            }

            dependencies = new List<string>();
            foreach (string sDependencyName in dependencyFilter)
            {
                dependencies.Add(sDependencyName);
            }

            // Module names must be unique
            foreach(Module m in m_modules)
            {
                if (m.GetName() == sName)
                {
                    return false;
                }
            }

            ModuleConfig moduleConfig = new ModuleConfig(m_iNextModuleUid++, sName, m_eventManager, m_engineEvents, dependencies);
            ModuleType module = null;

            // Locate a constructor with the correct parameters. The first viable constructor will be used. Valid
            // formats are:
            // 1) ConfigType, ModuleConfig
            // 2) ModuleConfig, ConfigType
            // 3) ModuleConfig
            
            ConstructorInfo[] constructors = typeof(ModuleType).GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                if (parameters.Length == 1)
                {
                    if (parameters[0].ParameterType == typeof(ModuleConfig))
                    {
                        module = (ModuleType)Activator.CreateInstance(typeof(ModuleType), moduleConfig);
                        break;
                    }
                }
                else if (parameters.Length == 2)
                {
                    if (parameters[0].ParameterType == typeof(ModuleConfig) && parameters[1].ParameterType == typeof(ConfigType))
                    {
                        module = (ModuleType)Activator.CreateInstance(typeof(ModuleType), moduleConfig, config);
                        break;
                    }
                    else if (parameters[0].ParameterType == typeof(ConfigType) && parameters[1].ParameterType == typeof(ModuleConfig))
                    {
                        module = (ModuleType)Activator.CreateInstance(typeof(ModuleType), config, moduleConfig);
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            if (module == null)
            {
                throw new ModuleException("Failed to construct module of type " + typeof(ModuleType).Name +  
                    " with name '" + sName + "'. A constructor accepting one of the following is required: " +
                    "(ModuleConfig), (ModuleConfig, CustomParameter) or (CustomParameter, ModuleConfig).");
            }

            m_modules.Add(module);
            m_eventManager.LaunchEvent(m_iModuleAvailableEventUid, module);
            return true;
        }
        
        /// <summary>
        /// Adds an api context with the given configuration. See the api context configuration documentation for
        /// details on each option. Returns -1 if the configuration was invalid.
        /// </summary>
        /// <param name="config">The context configuration</param>
        /// <returns>The context uid, or -1</returns>
        public int AddApiContext(ApiContextConfig config)
        {
            if (config == null)
            {
                return -1;
            }

            ApiContext newContext = new ApiContext(config.GetDatabaseAddress());

            int iApiContextUid = m_iNextApiContextUid++;
            m_apiContexts.Add(iApiContextUid, newContext);

            return iApiContextUid;
        }

        /// <summary>
        /// Removes an api context with the given uid. If no such context exists, this function does
        /// nothing.
        /// </summary>
        /// <param name="iApiContextUid">The uid of the context to remove</param>
        public void RemoveApiContext(int iApiContextUid)
        {
            m_apiContexts.Remove(iApiContextUid);
        }

        /// <summary>
        /// Constructs an instance of the engines api configured to operate within the given context. 
        /// </summary>
        /// <param name="iApiContextUid">The id of the api context to construct with</param>
        /// <returns>An api context or null</returns>
        public EngineApi GetApi(int iApiContextUid)
        {
            ApiContext context;
            if (m_apiContexts.TryGetValue(iApiContextUid, out context))
            {
                EngineApi api = new EngineApi(context, m_engineEvents);
                m_eventManager.AddEventListener(api, m_iModuleAvailableEventUid);
                m_eventManager.AddEventListener(api, m_iModuleUnavailableEventUid);
                m_eventManager.AddEventListener(api, m_iApiConstructedEventUid);

                m_eventManager.LaunchEvent(m_iApiConstructedEventUid, m_modules);
                return api;
            }

            return null;
        }

        public void OnEventReceived<DataType>(Event<DataType> eve)
        {
            if (eve == null)
            {
                return;
            }

            if (eve.GetEventTypeId() == m_iDependencyRequestEventUid)
            {
                string sDependencyName = eve.GetData() as string;
                if (sDependencyName != null)
                {
                    foreach (Module module in m_modules)
                    {
                        if (module.GetName() == sDependencyName)
                        {
                            m_eventManager.LaunchEvent(m_iModuleAvailableEventUid, module);
                            return;
                        }
                    }
                }
            }
        }
    }
}
