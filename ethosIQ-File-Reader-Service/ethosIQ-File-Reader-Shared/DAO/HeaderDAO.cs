using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.DAO
{
    public class HeaderDAO
    {
        public Database ConfigurationDatabase;

        public HeaderDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public List<Header> GetHeadersByFileTypeID(int FileTypeID)
        {
            DataSet dataSet = new DataSet();
            List<Header> Headers = new List<Header>();

            if (ConfigurationDatabase != null)
            {
                string selectStatement = "SELECT * FROM FILE_HEADER WHERE FILETYPEID = " + FileTypeID;

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        using (IDataReader reader = statement.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                Headers.Add(new Header(Convert.ToInt32(reader["FILETYPEID"]), Convert.ToInt32(reader["HEADERNUMBER"]), reader["HEADERNAME"].ToString()));
                            }
                        }

                        //IDataAdapter adapter = ConfigurationDatabase.CreateDataAdapter(statement);

                        //adapter.Fill(dataSet);
                    }
                }
            }

            return Headers;
        }

        public void Insert(Header Header)
        {
            string insertStatement = "INSERT INTO FILE_HEADER (FILETYPEID, HEADERNUMBER, HEADERNAME, HEADERDATA) VALUES (" + Header.FileTypeID + "," + Header.HeaderNumber + ",'" + Header.HeaderName + "','" + Header.HeaderData + "')";

            using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
            {
                using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                {
                    connection.Open();

                    statement.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int FileTypeID, int HeaderNumber)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_HEADER WHERE FILETYPEID = " + FileTypeID + " AND HEADERNUMBER = " + HeaderNumber;

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

        public void DeleteAll(int FileTypeID)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_HEADER WHERE FILETYPEID = " + FileTypeID;

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
