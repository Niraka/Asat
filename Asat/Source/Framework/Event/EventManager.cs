using System.Collections.Generic;

namespace Asat.Framework.Event
{
    public class EventManager
    {
        private int m_iNextEventUid;
        private int m_iNextEventTypeUid;
        private SortedDictionary<string, int> m_eventTypeNameMappings;
        private SortedDictionary<int, EventTypeDetails> m_eventTypes;

        public EventManager()
        {
            m_iNextEventUid = 0;
            m_iNextEventTypeUid = 0;
            m_eventTypeNameMappings = new SortedDictionary<string, int>();
            m_eventTypes = new SortedDictionary<int, EventTypeDetails>();
        }

        /// <summary>
        /// Adds an event with the given name. Events names must be unique across all currently registered
        /// events. Null or empty names are rejected.
        /// </summary>
        /// <param name="sEventTypeName">The name by which the event will be referred to</param>
        /// <returns>The event type uid, or -1 </returns>
        public int AddEventType(string sEventTypeName)
        {
            if (string.IsNullOrWhiteSpace(sEventTypeName))
            {
                return -1;
            }

            int iEventTypeUid = GetEventTypeUid(sEventTypeName);
            if (iEventTypeUid != -1)
            {
                return -1;
            }

            EventTypeDetails details = new EventTypeDetails(m_iNextEventTypeUid++, sEventTypeName);
            m_eventTypes[details.iUid] = details;
            m_eventTypeNameMappings[sEventTypeName] = details.iUid;
            return details.iUid;
        }
        
        /// <summary>
        /// Removes an event type with the given uid. Any event listeners currently subscribed to the event
        /// are unlinked. If no event with the given uid existed, this function does nothing.
        /// </summary>
        /// <param name="iEventTypeUid">The uid of the event type to remove</param>
        public void RemoveEventType(int iEventTypeUid)
        {
            EventTypeDetails details;
            if (m_eventTypes.TryGetValue(iEventTypeUid, out details))
            {
                m_eventTypeNameMappings.Remove(details.sName);
                m_eventTypes.Remove(iEventTypeUid);
            }
        }

        /// <summary>
        /// Gets the type uid for the event with the given name. Returns -1 if no event with the given name
        /// existed.
        /// </summary>
        /// <param name="sEventTypeName">The name of the event whose type uid should be gotten </param>
        /// <returns>The event type uid, or -1</returns>
        public int GetEventTypeUid(string sEventTypeName)
        {
            if (string.IsNullOrWhiteSpace(sEventTypeName))
            {
                return -1;
            }

            int iEventTypeUid = -1;
            if (m_eventTypeNameMappings.TryGetValue(sEventTypeName, out iEventTypeUid))
            {
                return iEventTypeUid;
            }
            return -1;
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
            Event<DataType> eve = new Event<DataType>(m_iNextEventUid++, iEventTypeUid, data);
            EventTypeDetails details;
            if (m_eventTypes.TryGetValue(iEventTypeUid, out details))
            {
                foreach (EventListener listener in details.EventListeners)
                {
                    listener.OnEventReceived(eve);
                }
            }
        }

        /// <summary>
        /// Adds an event listener for the event with the given event type uid. If no such event type
        /// existed, this function does nothing.
        /// </summary>
        /// <param name="listener">The event listener to add</param>
        /// <param name="iEventTypeUid">The type uid of the event to listen to</param>
        public void AddEventListener(EventListener listener, int iEventTypeUid)
        {
            EventTypeDetails details;
            if (m_eventTypes.TryGetValue(iEventTypeUid, out details))
            {
                if (details.EventListeners.Contains(listener))
                {
                    return;
                }

                details.EventListeners.Add(listener);
            }
        }

        /// <summary>
        /// Removes all instances of the given event listener that are bound to the event with the given
        /// event type uid. If no such event type existed, this function does nothing.
        /// </summary>
        /// <param name="listener">The event listener to remove</param>
        /// <param name="iEventTypeUid">The uid of the event type to remove listeners from</param>
        public void RemoveEventListener(EventListener listener, int iEventTypeUid)
        {
            EventTypeDetails details;
            if (m_eventTypes.TryGetValue(iEventTypeUid, out details))
            {
                details.EventListeners.Remove(listener);
            }
        }

        /// <summary>
        /// Clears all event listeners for the event with the given event type uid. If no such event type
        /// existed, this function does nothing.
        /// </summary>
        /// <param name="iEventTypeUid">The uid of the event type to clear all listeners from</param>
        public void ClearEventListeners(int iEventTypeUid)
        {
            EventTypeDetails details;
            if (m_eventTypes.TryGetValue(iEventTypeUid, out details))
            {
                details.EventListeners.Clear();
            }
        }
    }
}
