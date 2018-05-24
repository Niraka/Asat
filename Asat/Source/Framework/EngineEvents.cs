using Asat.Framework.Event;
using System.Collections.Generic;

namespace Asat.Framework
{
    public class EngineEvents
    {
        public enum Types
        {
            MODULE_AVAILABLE,
            MODULE_UNAVAILABLE,
            API_CONSTRUCTED,
            DEPENDENCY_REQUEST
        }

        private EventManager m_eventManager;
        private static SortedDictionary<Types, string> m_typesAndNames = new SortedDictionary<Types, string>
        {
            { Types.MODULE_AVAILABLE, "module-added" },
            { Types.MODULE_UNAVAILABLE, "module-removed" },
            { Types.API_CONSTRUCTED, "api-constructed" },
            { Types.DEPENDENCY_REQUEST, "dependency-request" }
        };
        
        public EngineEvents(EventManager eventManager)
        {
            m_eventManager = eventManager;
            AddAllEvents();
        }

        private void AddAllEvents()
        {
            if (m_eventManager != null)
            {
                foreach (KeyValuePair<Types, string> eve in m_typesAndNames)
                {
                    m_eventManager.AddEventType(eve.Value);
                }
            }
        }

        public int GetEventTypeUid(Types type)
        {
            if (m_eventManager == null)
            {
                return -1;
            }
            else
            {
                string sEventTypeName = string.Empty;
                if (m_typesAndNames.TryGetValue(type, out sEventTypeName))
                {
                    return m_eventManager.GetEventTypeUid(sEventTypeName);
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
