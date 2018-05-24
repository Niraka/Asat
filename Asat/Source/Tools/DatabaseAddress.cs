namespace Asat.Tools
{
    public class DatabaseAddress
    {
        private string m_sServerName;
        private string m_sDatabaseName;

        public DatabaseAddress()
        {
            m_sServerName = string.Empty;
            m_sDatabaseName = string.Empty;
        }

        public DatabaseAddress(string sServerName,
            string sDatabaseName)
        {
            m_sServerName = sServerName == null ? string.Empty : sServerName.ToUpper();
            m_sDatabaseName = sDatabaseName == null ? string.Empty : sDatabaseName.ToUpper();
        }

        public DatabaseAddress(TableAddress address)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
        }

        public DatabaseAddress(ColumnAddress address)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
        }

        public string GetServerName()
        {
            return m_sServerName;
        }

        public string GetDatabaseName()
        {
            return m_sDatabaseName;
        }
    }
}
