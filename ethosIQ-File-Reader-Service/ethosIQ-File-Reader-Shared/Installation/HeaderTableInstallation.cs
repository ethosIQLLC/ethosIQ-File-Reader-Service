﻿using ethosIQ_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.Installation
{
    public static class HeaderTableInstallation
    {
        public static bool CreateHeaderTable(Database ConfigurationDatabase)
        {
            bool serverExists = false;
            if (ConfigurationDatabase != null)
            {
                string checkForTableQuery = "SELECT count(*) AS \"SERVEREXISTS\" FROM sqlite_master " +
                                            "WHERE type= 'table' " +
                                            "AND name = 'FILE_HEADER'";

                string createTableQuery = "CREATE TABLE FILE_HEADER" +
                                                "(" +
                                                "FILETYPEID INTEGER," +
                                                "HEADERNUMBER INTEGER," +
                                                "HEADERNAME TEXT," +
                                                "HEADERDATA TEXT" +
                                                ")";

                using (IDbConnection connection = ConfigurationDatabase.CreateOpenConnection())
                {
                    using (IDbCommand findTableCommand = ConfigurationDatabase.CreateCommand(checkForTableQuery, connection))
                    {
                        using (IDataReader reader = findTableCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                serverExists = Convert.ToBoolean(reader["SERVEREXISTS"]);
                            }
                        }
                    }
                }

                if (!serverExists)
                {
                    using (IDbConnection connection = ConfigurationDatabase.CreateOpenConnection())
                    {
                        using (IDbCommand initialize = ConfigurationDatabase.CreateCommand(createTableQuery, connection))
                        {
                            initialize.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }
            return false;

        }
    }
}
