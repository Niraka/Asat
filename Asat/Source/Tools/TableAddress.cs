namespace Asat.Tools
{
    public class TableAddress
    {
        private string m_sServerName;
        private string m_sDatabaseName;
        private string m_sTableName;
        public TableAddress()
        {
            m_sServerName = string.Empty;
            m_sDatabaseName = string.Empty;
            m_sTableName = string.Empty;
        }

        public TableAddress(string sServerName,
            string sDatabaseName,
            string sTableName)
        {
            m_sServerName = sServerName == null ? string.Empty : sServerName.ToUpper();
            m_sDatabaseName = sDatabaseName == null ? string.Empty : sDatabaseName.ToUpper();
            m_sTableName = sTableName == null ? string.Empty : sTableName.ToUpper();
        }

        public TableAddress(DatabaseAddress address, string sTableName)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
            m_sTableName = sTableName == null ? string.Empty : sTableName.ToUpper();
        }

        public TableAddress(ColumnAddress address)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
            m_sTableName = address.GetTableName();
        }

        public string GetServerName()
        {
            return m_sServerName;
        }

        public string GetDatabaseName()
        {
            return m_sDatabaseName;
        }

        public string GetTableName()
        {
            return m_sTableName;
        }
    }
}
