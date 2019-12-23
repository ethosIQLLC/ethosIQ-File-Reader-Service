using ethosIQ_Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace ethosIQ_File_Reader_Shared.DAO
{
    public class FileSourceDAO
    {
        Database ConfigurationDatabase;

        public FileSourceDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public List<FileSource> GetAllFileSources()
        {
            List<FileSource> FileSources = new List<FileSource>();

            if (ConfigurationDatabase != null)
            {
                string selectStatement = "SELECT * FROM FILE_SOURCE";

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand getAllEnabledGenesysSitesCommand = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        using (IDataReader reader = getAllEnabledGenesysSitesCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int FileTypeID = 0;

                                if (reader["FILETYPEID"] == DBNull.Value)
                                {
                                    FileTypeID = 0;
                                }
                                else
                                {
                                    FileTypeID = Convert.ToInt32(reader["FILETYPEID"]);
                                }

                                FileSources.Add(new FileSource(Convert.ToInt32(reader["FILESOURCEID"]), FileTypeID, reader["NAME"].ToString(), reader["DIRECTORY"].ToString()));
                            }
                        }
                    }
                }
            }

            return FileSources;
        }

        public int Insert(FileSource FileSource)
        {
            int result = 0;

            if (ConfigurationDatabase != null)
            {
                List<FileSource> CurrentFileTypes = new List<FileSource>();

                string selectORStatement = "SELECT * FROM FILE_SOURCE WHERE NAME = '" + FileSource.Name + "' OR DIRECTORY = '" + FileSource.Directory + "'";

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectORStatement, connection))
                    {
                        connection.Open();

                        IDataReader reader = statement.ExecuteReader();

                        while (reader.Read())
                        {
                            CurrentFileTypes.Add(new FileSource(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
                        }
                    }
                }

                if (CurrentFileTypes.Count == 0)
                {
                    string insertStatement = "INSERT INTO FILE_SOURCE (FILETYPEID, NAME, DIRECTORY) VALUES (" + FileSource.FileTypeID +",'" + FileSource.Name + "','" + FileSource.Directory + "')";

                    using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                    {
                        using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                        {
                            connection.Open();

                            statement.ExecuteNonQuery();
                        }
                    }

                    string selectStatement = "SELECT FILETYPEID FROM FILE_SOURCE WHERE NAME = '" + FileSource.Name + "'";

                    using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                    {
                        using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                        {
                            connection.Open();

                            IDataReader reader = statement.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader.GetValue(0) == DBNull.Value)
                                {
                                    result = 0;
                                }
                                else
                                {
                                    result = Convert.ToInt32(reader.GetValue(0));
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public void Delete(string Name)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_SOURCE WHERE NAME = '" + Name + "'";

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(deleteStatement, connection))
                    {
                        connection.Open();

                        statement.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
