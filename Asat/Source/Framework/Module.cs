using System;
using Asat.Framework.Event;
using System.Collections.Generic;

namespace Asat.Framework
{
    public abstract class Module : Event.EventListener
    {
        private EventManager m_eventManager;
        private EngineEvents m_engineEvents;
        private List<string> m_dependencies;
        private string m_sName;
        private int m_iUid;

        private int m_iModuleAvailableEventUid;
        private int m_iModuleUnavailableEventUid;
        private int m_iDependencyRequestEventUid;

        public Module(ModuleConfig config)
        {
            m_eventManager = config.GetEventManager();
            m_dependencies = config.GetDependencies();
            m_sName = config.GetName();
            m_iUid = config.GetUid();

            m_iModuleAvailableEventUid = config.GetEngineEvents().
                GetEventTypeUid(EngineEvents.Types.MODULE_AVAILABLE);
            m_iModuleUnavailableEventUid = config.GetEngineEvents().
                GetEventTypeUid(EngineEvents.Types.MODULE_UNAVAILABLE);
            m_iDependencyRequestEventUid = config.GetEngineEvents().
                GetEventTypeUid(EngineEvents.Types.DEPENDENCY_REQUEST);

            m_eventManager.AddEventListener(this, m_iModuleAvailableEventUid);
            m_eventManager.AddEventListener(this, m_iModuleUnavailableEventUid);
            
            foreach (string sDependencyName in config.GetDependencies())
            {
                m_eventManager.LaunchEvent(m_iDependencyRequestEventUid, sDependencyName);
            }
        }

        public int GetUid()
        {
            return m_iUid;
        }

        public string GetName()
        {
            return m_sName;
        }

        public List<string> GetDependencies()
        {
            return m_dependencies;
        }

        /// <summary>
        /// Adds an event with the given name. Events names must be unique across all currently registered
        /// events. Null or empty names are rejected.
        /// </summary>
        /// <param name="sEventTypeName">The name by which the event will be referred to</param>
        /// <returns>The event type uid, or -1 </returns>
        public int AddEventType(string sEventTypeName)
        {
            return m_eventManager.AddEventType(sEventTypeName);
        }

        /// <summary>
        /// Removes an event type with the given uid. Any event listeners currently subscribed to the event
        /// are unlinked. If no event with the given uid existed, this function does nothing.
        /// </summary>
        /// <param name="iEventTypeUid">The uid of the event type to remove</param>
        public void RemoveEventType(int iEventTypeUid)
        {
            m_eventManager.RemoveEventType(iEventTypeUid);
        }

        /// <summary>
        /// Gets the type uid for the event with the given name. Returns -1 if no event with the given name
        /// existed.
        /// </summary>
        /// <param name="sEventTypeName">The name of the event whose type uid should be gotten </param>
        /// <returns>The event type uid, or -1</returns>
        public int GetEventTypeUid(string sEventTypeName)
        {
            return m_eventManager.GetEventTypeUid(sEventTypeName);
        }

        /// <summary>
        /// Launches an event of the given type.
        /// </summary>
        /// <param name="iEventTypeUid">The uid of the event type to launch</param>
        public void LaunchEvent(int iEventTypeUid)
        {
            LaunchEvent<object>(iEventTypeUid, null);
        }

        /// <summary>
        /// Launches an event of the given type.
        /// </summary>
        /// <typeparam name="DataType">The type of data to attach to the event</typeparam>
        /// <param name="iEventTypeUid">The uid of the event type to launch</param>
        /// <param name="data">The data to attach to the event</param>
        public void LaunchEvent<DataType>(int iEventTypeUid, DataType data)
        {
            m_eventManager.LaunchEvent<DataType>(iEventTypeUid, data);
        }

        /// <summary>
        /// Adds an event listener for the event with the given event type uid. If no such event type
        /// existed, this function does nothing.
        /// </summary>
        /// <param name="listener">The event listener to add</param>
        /// <param name="iEventTypeUid">The type uid of the event to listen to</param>
        public void AddEventListener(EventListener listener, int iEventTypeUid)
        {
            m_eventManager.AddEventListener(listener, iEventTypeUid);
        }

        /// <summary>
        /// Removes all instances of the given event listener that are bound to the event with the given
        /// event type uid. If no such event type existed, this function does nothing.
        /// </summary>
        /// <param name="listener">The event listener to remove</param>
        /// <param name="iEventTypeUid">The uid of the event type to remove listeners from</param>
        public void RemoveEventListener(EventListener listener, int iEventTypeUid)
        {
            m_eventManager.RemoveEventListener(listener, iEventTypeUid);
        }

        /// <summary>
        /// Clears all event listeners for the event with the given event type uid. If no such event type
        /// existed, this function does nothing.
        /// </summary>
        /// <param name="iEventTypeUid">The uid of the event type to clear all listeners from</param>
        public void ClearEventListeners(int iEventTypeUid)
        {
            m_eventManager.ClearEventListeners(iEventTypeUid);
        }

        /// <summary>
        /// Called when an event type that this event listener is listening to is launched.
        /// </summary>
        /// <typeparam name="DataType">The type of data attached to the event</typeparam>
        /// <param name="eve">The event</param>
        public void OnEventReceived<DataType>(Event<DataType> eve)
        {
            if (eve == null)
            {
                return;
            }

            if (eve.GetEventTypeId() == m_iModuleAvailableEventUid)
            {
                Module m = eve.GetData() as Module;
                if (m != null)
                {
                    foreach (string sDependency in m_dependencies)
                    {
                        if (m.GetName() == sDependency)
                        {
                            OnDependencyAvailable(m);
                            return;
                        }
                    }
                }
            }
            else if (eve.GetEventTypeId() == m_iModuleUnavailableEventUid)
            {
                Module m = eve.GetData() as Module;
                if (m != null)
                {
                    foreach (string sDependency in m_dependencies)
                    {
                        if (m.GetName() == sDependency)
                        {
                            OnDependencyUnavailable(m);
                            return;
                        }
                    }
                }
            }
        }

        public virtual void OnDependencyAvailable(Module module)
        {
        }

        public virtual void OnDependencyUnavailable(Module module)
        {
        }
    }
}
