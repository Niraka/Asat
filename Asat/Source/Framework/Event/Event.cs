namespace Asat.Framework.Event
{
    public class Event<DataType>
    {
        private int m_iEventId;
        private int m_iEventTypeId;
        private DataType m_data;

        public Event()
        {
            m_iEventId = -1;
            m_iEventTypeId = -1;
            m_data = default(DataType);
        }

        public Event(int iEventId, int iEventTypeId, DataType data)
        {
            m_iEventId = iEventId;
            m_iEventTypeId = iEventTypeId;
            m_data = data;
        }

        public int GetEventId()
        {
            return m_iEventId;
        }

        public int GetEventTypeId()
        {
            return m_iEventTypeId;
        }

        public DataType GetData()
        {
            return m_data;
        }
    }
}
