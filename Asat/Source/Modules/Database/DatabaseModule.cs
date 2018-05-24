using System.Collections.Generic;
using Asat.Framework;
using Asat.Framework.Event;

namespace Asat.Modules.Database
{
    class TableConfig
    {
        private string m_sTableName;

        public TableConfig(string sTableName)
        {
            m_sTableName = sTableName;
        }

        public void AddColumn()
        {

        }

        public string GetTableName()
        {
            return m_sTableName;
        }
    }


    class DatabaseModule : Framework.Module
    {
        public DatabaseModule(ModuleConfig config) : base(config)
        {
        }

        public void CreateTable(TableConfig config)
        {

        }

        public void DestroyTable(string sTableName)
        {

        }

        public List<string> GetTableNames()
        {
            // SELECT TABLE_NAME FROM MMORPG.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'
            return new List<string>();
        }

        public List<string> GetViewNames()
        {
            // SELECT TABLE_NAME FROM MMORPG.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'
            return new List<string>();
        }

        public List<string> GetColumnNames(string sTableName)
        {
            // SELECT TABLE_NAME FROM MMORPG.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'SETTINGS'
            return new List<string>();
        }
    }
}
