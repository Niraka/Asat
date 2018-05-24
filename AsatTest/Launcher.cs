using System;
using Asat.Tools;
using Asat.Framework;
using Asat.Framework.Event;
using Asat.Modules.Validation;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AsatTest
{
    class Servers
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public int MaxConnectedUsers { get; set; }
        public int GlobalExpMultiplier { get; set; }
        public string PermittedAccountTypesTableName { get; set; }
    }

    class SqlModule
    {
        public void ValidateDatabase(TableSpecification spec)
        {
            
        }
    }

    class TableSpecification
    {
        private string m_sName;

        public TableSpecification(string sName)
        {
            m_sName = sName;
        }

        public void AddColumn(ColumnSpecification spec)
        {

        }
    }

    class ColumnSpecification
    {
        private string m_sName;

        public ColumnSpecification(string sName)
        {
            m_sName = sName;
        }
    }

    class Launcher
    {
        static void Main(string[] args)
        {
            //using (IDbConnection db = new SqlConnection("Data Source=Jenkins;Initial Catalog=MMORPG;Integrated Security=True"))
            //{
            //    List<Servers> s = new List<Servers>(db.Query<Servers>("Select * from servers"));
            //}

            //TableSpecification spec = new TableSpecification();
            //spec.AddColumn(new ColumnSpecification());
            //spec.AddColumn(new ColumnSpecification());
            //spec.AddColumn(new ColumnSpecification());
            //
            //SqlModule sql = new SqlModule();
            //sql.ValidateDatabase(spec);

            
            // Construct engine
            Engine engine = new Engine(new EngineConfig("test"));
            
            // Create a context
            int iContextUid = engine.AddApiContext(new ApiContextConfig(
                new DatabaseAddress("d2sql4.d2.wdm", "northern_ireland_rms_dvl")));
            
            // Get api
            EngineApi api = engine.GetApi(iContextUid);
            api.GetContext();

            Console.ReadLine();
        }
    }
}
