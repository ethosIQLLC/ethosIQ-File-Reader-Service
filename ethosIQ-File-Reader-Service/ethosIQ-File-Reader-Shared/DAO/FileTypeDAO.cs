using ethosIQ_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.DAO
{
    public class FileTypeDAO
    {
        public Database ConfigurationDatabase;

        public FileTypeDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public int CreateFileType(FileType FileType)
        {
            int result = 0;

            if (ConfigurationDatabase != null)
            {
                List<FileType> CurrentFileTypes = new List<FileType>();

                string selectStatement = "SELECT * FROM FILE_TYPE WHERE NAME = '" + FileType.Name + "'";

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        IDataReader reader = statement.ExecuteReader();

                        while (reader.Read())
                        {
                            CurrentFileTypes.Add(new FileType(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString()));
                        }
                    }
                }

                if (CurrentFileTypes.Count == 0)
                {
                    string insertStatement = "INSERT INTO FILE_TYPE (NAME, DELIMITER, DATABASESTOREDPROCEDURENAME) VALUES ('" + FileType.Name + "','" + FileType.Delimiter + "','" + FileType.DatabaseStoredProcedureName + "')";

                    using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                    {
                        using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                        {
                            connection.Open();

                            statement.ExecuteNonQuery();
                        }
                    }

                    using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                    {
                        using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                        {
                            connection.Open();

                            IDataReader reader = statement.ExecuteReader();

                            while (reader.Read())
                            {
                                result = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public FileType GetFileType(int FileTypeID)
        {
            FileType FileType = null;

            string selectStatement = "SELECT * FROM FILE_TYPE WHERE FILETYPEID = " + FileTypeID;

            using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
            {
                using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                {
                    connection.Open();

                    IDataReader reader = statement.ExecuteReader();

                    while (reader.Read())
                    {
                        FileType = new FileType(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString());
                    }
                }
            }

            return FileType;
        }

        public List<FileType> GetAllFileTypes()
        {
            List<FileType> FileTypes = new List<FileType>();

            string selectStatement = "SELECT * FROM FILE_TYPE";

            using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
            {
                using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                {
                    connection.Open();

                    IDataReader reader = statement.ExecuteReader();

                    while (reader.Read())
                    {
                        FileTypes.Add(new FileType(Convert.ToInt32(reader.GetValue(0)),reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString()));
                    }
                }
            }

            return FileTypes;
        }

        public void Delete(int FileTypeID)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_TYPE WHERE FILETYPEID = " + FileTypeID;

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
