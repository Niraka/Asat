using System.Collections.Generic;

namespace Asat.Framework
{
    public class ModuleConfig
    {
        private int m_iUid;
        private string m_sName;
        private Event.EventManager m_eventManager;
        private EngineEvents m_engineEvents;
        private List<string> m_dependencies;

        public ModuleConfig(int iUid, string sName, Event.EventManager eventManager, EngineEvents engineEvents, List<string> dependencies)
        {
            m_iUid = iUid;
            m_sName = sName;
            m_eventManager = eventManager;
            m_engineEvents = engineEvents;
            m_dependencies = (dependencies == null) ? new List<string>() : dependencies;
        }

        public int GetUid()
        {
            return m_iUid;
        }

        public string GetName()
        {
            return m_sName;
        }

        public Event.EventManager GetEventManager()
        {
            return m_eventManager;
        }

        public EngineEvents GetEngineEvents()
        {
            return m_engineEvents;
        }

        public List<string> GetDependencies()
        {
            return m_dependencies;
        }
    }
}
