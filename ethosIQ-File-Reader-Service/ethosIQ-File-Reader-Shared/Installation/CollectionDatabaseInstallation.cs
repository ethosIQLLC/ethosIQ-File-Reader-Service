using ethosIQ_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.Installation
{
    public static class CollectionDatabaseInstallation
    {
        
        public static bool CreateCollectionDatabaseTable(Database Database)
        {
            bool tableExists = false;
            if (Database != null)
            {
                string checkForTableQuery = "SELECT count(*) AS \"TABLEEXISTS\" FROM sqlite_master " +
                                            "WHERE type= 'table' " +
                                            "AND name = 'ETHOSIQ_COLLECTION_DATABASE'";

                string createTableStatement = "CREATE TABLE ETHOSIQ_COLLECTION_DATABASE" +
                                                "(" +
                                                "ETHOSIQ_COLLECTION_DATABASE_ID INTEGER PRIMARY KEY," +
                                                "TYPE TEXT," +
                                                "DATASOURCE TEXT," +
                                                "SERVER TEXT," +
                                                "PORT INTEGER," +
                                                "USERNAME TEXT," +
                                                "PASSWORD TEXT," +
                                                "HEARTBEATINTERVAL INTEGER" +
                                                ")";

                using (IDbConnection connection = Database.CreateOpenConnection())
                {
                    using (IDbCommand findTableCommand = Database.CreateCommand(checkForTableQuery, connection))
                    {
                        using (IDataReader reader = findTableCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tableExists = Convert.ToBoolean(reader["TABLEEXISTS"]);
                            }
                        }
                    }
                }

                if (!(tableExists))
                {
                    using (IDbConnection connection = Database.CreateOpenConnection())
                    {
                        using (IDbCommand createTableCommand = Database.CreateCommand(createTableStatement, connection))
                        {
                            createTableCommand.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
    }
}
