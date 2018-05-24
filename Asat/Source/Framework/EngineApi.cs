using System;
using System.Collections.Generic;
using Asat.Framework.Event;

namespace Asat.Framework
{
    public class EngineApi : Event.EventListener
    {
        private ApiContext m_context;
        private Modules.Disk.DiskModule m_diskModule;
        private Modules.Network.NetworkModule m_networkModule;
        private Modules.Database.DatabaseModule m_databaseModule;
        private Modules.Validation.ValidationModule m_validationModule;
        private Modules.Settings.SettingsModule m_settingsModule;
        private int m_iModuleAvailableEventUid;
        private int m_iModuleUnavailableEventUid;
        private int m_iApiConstructedEventUid;
        
        public EngineApi(ApiContext context, EngineEvents engineEvents)
        {
            m_context = context == null ? new ApiContext() : context;
            if (engineEvents != null)
            {
                m_iModuleAvailableEventUid = engineEvents.GetEventTypeUid(EngineEvents.Types.MODULE_AVAILABLE);
                m_iModuleUnavailableEventUid = engineEvents.GetEventTypeUid(EngineEvents.Types.MODULE_UNAVAILABLE);
                m_iApiConstructedEventUid = engineEvents.GetEventTypeUid(EngineEvents.Types.API_CONSTRUCTED);
            }
            else
            {
                m_iModuleAvailableEventUid = -1;
                m_iModuleUnavailableEventUid = -1;
                m_iApiConstructedEventUid = -1;
            }
        }

        /// <summary>
        /// Gets the context that the engine api is currently executing under.
        /// </summary>
        /// <returns>The api context</returns>
        public ApiContext GetContext()
        {
            return m_context;
        }
        
        public void OnEventReceived<DataType>(Event<DataType> eve)
        {
            if (eve == null)
            {
                return;
            }

            if (eve.GetEventTypeId() == m_iModuleAvailableEventUid)
            {
                // When a module is added, bind it to the respective functionality. Obviously this only works
                // for modules that are known at compile time as the type must be known.
                AddModule(eve.GetData());
            }
            else if (eve.GetEventTypeId() == m_iModuleUnavailableEventUid)
            {
                // When a module is removed, unbind the respective functionality. Obviously this only works
                // for modules that are known at compile time as the type must be known.
                Module module = eve.GetData() as Modules.Validation.ValidationModule;
                if (module != null)
                {
                    m_validationModule = null;
                    return;
                }

                module = eve.GetData() as Modules.Disk.DiskModule;
                if (module != null)
                {
                    m_diskModule = null;
                    return;
                }

                module = eve.GetData() as Modules.Network.NetworkModule;
                if (module != null)
                {
                    m_networkModule = null;
                    return;
                }

                module = eve.GetData() as Modules.Database.DatabaseModule;
                if (module != null)
                {
                    m_databaseModule = null;
                    return;
                }

                module = eve.GetData() as Modules.Settings.SettingsModule;
                if (module != null)
                {
                    m_settingsModule = null;
                    return;
                }
            }
            else if (eve.GetEventTypeId() == m_iApiConstructedEventUid)
            {
                List<Module> modules = eve.GetData() as List<Module>;
                if (modules != null)
                {
                    foreach (Module m in modules)
                    {
                        AddModule(m);
                    }
                }
            }
        }

        private void AddModule<ModuleType>(ModuleType module)
        {
            Module tempModule = module as Modules.Validation.ValidationModule;
            if (tempModule != null)
            {
                m_validationModule = (Modules.Validation.ValidationModule)tempModule;
                return;
            }

            tempModule = module as Modules.Disk.DiskModule;
            if (tempModule != null)
            {
                m_diskModule = (Modules.Disk.DiskModule)tempModule;
                return;
            }

            tempModule = module as Modules.Network.NetworkModule;
            if (tempModule != null)
            {
                m_networkModule = (Modules.Network.NetworkModule)tempModule;
                return;
            }

            tempModule = module as Modules.Database.DatabaseModule;
            if (tempModule != null)
            {
                m_databaseModule = (Modules.Database.DatabaseModule)tempModule;
                return;
            }

            tempModule = module as Modules.Settings.SettingsModule;
            if (tempModule != null)
            {
                m_settingsModule = (Modules.Settings.SettingsModule)tempModule;
                return;
            }
        }
    }
}
