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
    public class DataDAO
    {
        public Database CollectionDatabase;

        public DataDAO(Database CollectionDatabase)
        {
            this.CollectionDatabase = CollectionDatabase;
        }

        public void TruncateTable(string TableName)
        {
            using (IDbConnection Connection = CollectionDatabase.CreateOpenConnection())
            {
                using (IDbCommand Command = CollectionDatabase.CreateCommand("TRUNCATE TABLE " + TableName, Connection))
                {
                    Command.ExecuteNonQuery();

                    if (Command.Transaction != null)
                    {
                        Command.Transaction.Commit();
                    }
                }
            }
        }

        public void Insert(string TableName, List<Column> Columns)
        {
            string InsertString = "INSERT INTO " + TableName + " (";

            foreach (Column column in Columns.OrderBy(x => x.ColumnNumber))
            {
                if (!column.Ignore)
                {
                    if (column.DatabaseColumnName == string.Empty || column.DatabaseColumnName == null)
                    {
                        //Command.Parameters.Add(CollectionDatabase.CreateParameter(column.ColumnName, column.ColumnData));
                        InsertString += column.ColumnName + ", ";
                    }
                    else
                    {
                        //Command.Parameters.Add(CollectionDatabase.CreateParameter(column.DatabaseColumnName, column.ColumnData));
                        InsertString += column.DatabaseColumnName + ",";
                    }
                }
            }

            InsertString = InsertString.Remove(InsertString.Count() - 1);

            InsertString += ") VALUES (";

            foreach (Column column in Columns.OrderBy(x => x.ColumnNumber))
            {
                if (!column.Ignore)
                {
                    if (column.ColumnData is string)
                    {
                        InsertString += "'" + column.ColumnData.ToString() + "',";
                    }
                    else if (column.ColumnData is DateTime)
                    {
                        //InsertString += "to_date('" + column.ColumnData.ToString() + "','mm/dd/yyyy hh:mi:ss am'),";
                        InsertString += CollectionDatabase.FormatDateTime((DateTime)column.ColumnData) + ",";
                    }
                    else if (column.ColumnData is int)
                    {
                        InsertString += Convert.ToInt32(column.ColumnData) + ",";
                    }
                    else
                    {
                        InsertString += column.ColumnData + ",";
                    }
                }
            }

            InsertString = InsertString.Remove(InsertString.Count() - 1);

            InsertString += ")";

            Console.WriteLine(InsertString);

            using (IDbConnection Connection = CollectionDatabase.CreateOpenConnection())
            {
                using (IDbCommand Command = CollectionDatabase.CreateCommand(InsertString, Connection))
                {
                    Command.ExecuteNonQuery();

                    if(Command.Transaction != null)
                    {
                        Command.Transaction.Commit();
                    }
                }
            }
        }
    }
}
