using System;
using System.Collections.Generic;

namespace Asat.Framework.Event
{
    public class EventTypeDetails
    {
        public int iUid;
        public string sName;
        public List<EventListener> EventListeners;

        public EventTypeDetails()
        {
            iUid = -1;
            sName = string.Empty;
            EventListeners = new List<EventListener>();
        }

        public EventTypeDetails(int iUid, string sName)
        {
            this.iUid = iUid;
            this.sName = sName;
            EventListeners = new List<EventListener>();
        }
    }
}
