using Asat.Tools;

namespace Asat.Framework
{
    public class ApiContextConfig
    {
        private DatabaseAddress m_databaseAddress;
        
        public ApiContextConfig()
        {
            m_databaseAddress = new DatabaseAddress();
        }

        public ApiContextConfig(DatabaseAddress address)
        {
            m_databaseAddress = address;
        }

        public DatabaseAddress GetDatabaseAddress()
        {
            return m_databaseAddress;
        }
    }
}
