using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.Data;

namespace ethosIQ_File_Reader_Shared.DAO
{
    public class FooterDAO
    {
        public Database ConfigurationDatabase;

        public FooterDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public List<Footer> GetFootersByFileTypeID(int FileTypeID)
        {
            List<Footer> Footers = new List<Footer>();

            if (ConfigurationDatabase != null)
            {
                string selectStatement = "SELECT * FROM FILE_FOOTER WHERE FILETYPEID = " + FileTypeID;

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        using (IDataReader reader = statement.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Footers.Add(new Footer(Convert.ToInt32(reader["FILETYPEID"]), Convert.ToInt32(reader["FOOTERNUMBER"]), reader["FOOTERRNAME"].ToString()));
                            }
                        }
                    }
                }
            }

            return Footers;
        }

        public void Insert(Footer Footer)
        {
            string insertStatement = "INSERT INTO FILE_FOOTER (FILETYPEID, FOOTERNUMBER, FOOTERNAME) VALUES (" + Footer.FileTypeID + "," + Footer.FooterNumber + ",'" + Footer.FooterName + "')";

            using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
            {
                using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                {
                    connection.Open();

                    statement.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAll(int FileTypeID)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_FOOTER WHERE FILETYPEID = " + FileTypeID;

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

        public void Delete(int FileTypeID, int FooterNumber)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_FOOTER WHERE FILETYPEID = " + FileTypeID + " AND FOOTERNUMBER = " + FooterNumber;

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
