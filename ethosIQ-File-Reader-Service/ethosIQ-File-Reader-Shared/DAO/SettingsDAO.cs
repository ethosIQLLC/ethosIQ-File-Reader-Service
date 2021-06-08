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
    public class SettingsDAO
    {
        public Database ConfigurationDatabase;

        public SettingsDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public Settings GetSettingsByFileTypeID(int FileTypeID)
        {
            Settings Settings = null;

            if (ConfigurationDatabase != null)
            {
                string selectStatement = "SELECT * FROM FILE_SETTINGS WHERE FILETYPEID = " + FileTypeID;

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        using (IDataReader reader = statement.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Settings = new Settings(Convert.ToInt32(reader["FILETYPEID"]), 
                                                        Convert.ToBoolean(reader["USEFILENAME"]), 
                                                        Convert.ToBoolean(reader["USEFILEEXTENSION"]),
                                                        reader["TEXTTOIGNOREFILENAME"].ToString(),
                                                        reader["DATETIMEFORMATFILENAME"].ToString(),
                                                        reader["TEXTTOIGNOREFILEEXTENSION"].ToString(),
                                                        reader["DATETIMEFORMATFILEEXTENSION"].ToString(),
                                                        Convert.ToBoolean(reader["LINKDATETIME"]),
                                                        reader["DATETIMECOLUMN"].ToString(),
                                                        reader["DATETIMEFORMATLINKDATE"].ToString(),
                                                        Convert.ToBoolean(reader["TRUNCATETABLE"]));
                            }
                        }
                    }
                }
            }

            return Settings;
        }

        public void Insert(Settings Settings)
        {
            string insertStatement = "INSERT INTO FILE_SETTINGS (FILETYPEID, USEFILENAME, USEFILEEXTENSION, TEXTTOIGNOREFILENAME, DATETIMEFORMATFILENAME, TEXTTOIGNOREFILEEXTENSION, DATETIMEFORMATFILEEXTENSION, LINKDATETIME, DATETIMECOLUMN, DATETIMEFORMATLINKDATE, TRUNCATETABLE) VALUES (" + Settings.FileTypeID + "," + Convert.ToInt32(Settings.UseFileName) + "," + Convert.ToInt32(Settings.UseFileExtension) + ",'" + Settings.TextToIgnoreFileName + "','" + Settings.DateTimeFormatFileName + "','" + Settings.TextToIgnoreFileExtension + "','" + Settings.DateTimeFormatFileExtension + "'," + Convert.ToInt32(Settings.LinkDateTime) + ",'" + Settings.DateTimeColumn + "','" + Settings.DateTimeFormatLinkDate + "'," + Convert.ToInt32(Settings.TruncateTable) + ")";

            using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
            {
                using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                {
                    connection.Open();

                    statement.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int FileTypeID)
        {
            if (ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_SETTINGS WHERE FILETYPEID = " + FileTypeID;

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
