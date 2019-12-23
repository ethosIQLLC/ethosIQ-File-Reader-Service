using ethosIQ_Database;
using System;
using System.Data;

namespace ethosIQ_File_Reader_Shared.Configuration
{
    public class CollectionDatabaseConfiguration
    {
        private Database Database;

        public CollectionDatabaseConfiguration()
        {

        }

        public CollectionDatabaseConfiguration(Database Database)
        {
            this.Database = Database;
        }

        public Database GetCollectionDatabase()
        {
            Database CollectionDatabase = null;

            if (Database != null)
            {
                string getDBStatement = "SELECT * FROM ETHOSIQ_COLLECTION_DATABASE";

                using (IDbConnection connection = Database.CreateOpenConnection())
                {
                    using (IDbCommand getSiteByIdCommand = Database.CreateCommand(getDBStatement, connection))
                    {
                        using (IDataReader reader = getSiteByIdCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToDouble(reader["HEARTBEATINTERVAL"]) == 0)
                                {
                                    CollectionDatabase = DatabaseFactory.CreateDatabase(reader["TYPE"].ToString(),
                                                                                        reader["DATASOURCE"].ToString(),
                                                                                        reader["SERVER"].ToString(),
                                                                                        Convert.ToInt32(reader["PORT"]),
                                                                                        reader["USERNAME"].ToString(),
                                                                                        reader["PASSWORD"].ToString());
                                }
                                else
                                {
                                    CollectionDatabase = DatabaseFactory.CreateDatabase(reader["TYPE"].ToString(),
                                                    reader["DATASOURCE"].ToString(),
                                                    reader["SERVER"].ToString(),
                                                    Convert.ToInt32(reader["PORT"]),
                                                    reader["USERNAME"].ToString(),
                                                    reader["PASSWORD"].ToString(),
                                                    30,
                                                    1,
                                                    5);
                                }
                            }
                        }
                    }
                }
            }
            return CollectionDatabase;
        }

        public Database GetCollectionDatabaseManually(string Type, string DataSource, string Host, int Port, string Username, string Password)
        {
            return DatabaseFactory.CreateDatabase(Type, DataSource, Host, Port, Username, Password, 30, 1, 5);
        }
    }
}
