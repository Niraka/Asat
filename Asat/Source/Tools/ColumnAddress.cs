namespace Asat.Tools
{
    public class ColumnAddress
    {
        private string m_sServerName;
        private string m_sDatabaseName;
        private string m_sTableName;
        private string m_sColumnName;

        public ColumnAddress()
        {
            m_sServerName = string.Empty;
            m_sDatabaseName = string.Empty;
            m_sTableName = string.Empty;
            m_sColumnName = string.Empty;
        }

        public ColumnAddress(string sServerName,
            string sDatabaseName,
            string sTableName,
            string sColumnName)
        {
            m_sServerName = sServerName == null ? string.Empty : sServerName.ToUpper();
            m_sDatabaseName = sDatabaseName == null ? string.Empty : sDatabaseName.ToUpper();
            m_sTableName = sTableName == null ? string.Empty : sTableName.ToUpper();
            m_sColumnName = sColumnName == null ? string.Empty : sColumnName.ToUpper();
        }

        public ColumnAddress(DatabaseAddress address, string sTableName, string sColumnName)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
            m_sTableName = sTableName == null ? string.Empty : sTableName.ToUpper();
            m_sColumnName = sColumnName == null ? string.Empty : sColumnName.ToUpper();
        }

        public ColumnAddress(TableAddress address, string sColumnName)
        {
            m_sServerName = address.GetServerName();
            m_sDatabaseName = address.GetDatabaseName();
            m_sTableName = address.GetTableName();
            m_sColumnName = sColumnName == null ? string.Empty : sColumnName.ToUpper();
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

        public string GetColumnName()
        {
            return m_sColumnName;
        }
    }
}
