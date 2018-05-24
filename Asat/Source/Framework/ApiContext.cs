using Asat.Tools;

namespace Asat.Framework
{
    /// <summary>
    /// An engine api context is a collection of parameters that alters the way
    /// in which an engine api will operate.
    /// 
    /// E.G: A context containing a database address will automatically populate
    /// functions that require one. The function CreateTable(server, database, table)
    /// will become CreateTable(table)
    /// </summary>
    public class ApiContext
    {
        private DatabaseAddress m_databaseAddress;

        public ApiContext()
        {
            m_databaseAddress = new DatabaseAddress();
        }

        public ApiContext(DatabaseAddress address)
        {
            m_databaseAddress = address;
        }

        public DatabaseAddress GetDatabaseAddress()
        {
            return m_databaseAddress;
        }
    }
}
