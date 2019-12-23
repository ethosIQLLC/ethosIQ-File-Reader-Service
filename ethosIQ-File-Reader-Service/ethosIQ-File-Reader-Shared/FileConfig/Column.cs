using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class Column
    {
        public int FileTypeID;
        public int ColumnNumber;
        public string ColumnName;
        public string DatabaseColumnName;
        public object ColumnData;
        public bool Ignore;
        public bool NotInFile;
        

        public Column()
        {

        }

        public Column(int FileTypeID, int ColumnNumber, string ColumnName)
        {
            this.ColumnNumber = ColumnNumber;
            this.ColumnName = ColumnName;
        }

        public Column(int FileTypeID, int ColumnNumber, string ColumnName, string DatabaseColumnName, bool Ignore, bool NotInFile)
        {
            this.FileTypeID = FileTypeID;
            this.ColumnNumber = ColumnNumber;
            this.ColumnName = ColumnName;
            this.DatabaseColumnName = DatabaseColumnName;
            this.Ignore = Ignore;
            this.NotInFile = NotInFile;
        }
    }
}
