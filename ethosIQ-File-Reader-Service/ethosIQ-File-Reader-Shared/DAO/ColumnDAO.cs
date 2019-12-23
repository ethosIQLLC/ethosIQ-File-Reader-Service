using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.Data;

namespace ethosIQ_File_Reader_Shared.DAO
{
    public class ColumnDAO
    {
        public Database ConfigurationDatabase;

        public ColumnDAO(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public List<Column> Read(int FileTypeID)
        {
            List<Column> Columns = new List<Column>();

            if (ConfigurationDatabase != null)
            {
                string selectStatement = "SELECT * FROM FILE_COLUMN WHERE FILETYPEID = " + FileTypeID;

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(selectStatement, connection))
                    {
                        connection.Open();

                        using (IDataReader reader = statement.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Columns.Add(new Column(Convert.ToInt32(reader["FILETYPEID"]), Convert.ToInt32(reader["COLUMNNUMBER"]), reader["COLUMNNAME"].ToString(), reader["DATABASECOLUMNNAME"].ToString(), Convert.ToBoolean(reader["IGNORE"]), Convert.ToBoolean(reader["NOTINFILE"])));
                            }
                        }

                        //IDataAdapter adapter = ConfigurationDatabase.CreateDataAdapter(statement);

                        //adapter.Fill(dataSet);
                    }
                }
            }

            return Columns;
        }

        public void Insert(Column Column)
        {
            if (ConfigurationDatabase != null)
            {
                string insertStatement = "INSERT INTO FILE_COLUMN (FILETYPEID, COLUMNNUMBER, COLUMNNAME, DATABASECOLUMNNAME, COLUMNDATA, IGNORE, NOTINFILE) VALUES (" + Column.FileTypeID + "," + Column.ColumnNumber + ",'" + Column.ColumnName + "','" + Column.DatabaseColumnName + "','" + Column.ColumnData + "'," + Convert.ToInt32(Column.Ignore) + "," + Convert.ToInt32(Column.NotInFile) + ")";

                using (IDbConnection connection = ConfigurationDatabase.CreateConnection())
                {
                    using (IDbCommand statement = ConfigurationDatabase.CreateCommand(insertStatement, connection))
                    {
                        connection.Open();

                        statement.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(int FileTypeID, int ColumnNumber)
        {
            if(ConfigurationDatabase != null)
            {
                string deleteStatement = "DELETE FROM FILE_COLUMN WHERE FILETYPEID = " + FileTypeID + " AND COLUMNNUMBER = " + ColumnNumber;

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
                string deleteStatement = "DELETE FROM FILE_COLUMN WHERE FILETYPEID = " + FileTypeID;

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
