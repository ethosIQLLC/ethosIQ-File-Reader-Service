using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared
{
    public class FileType
    {
        public int FileTypeID;
        public string Name;
        public string Delimiter;
        public char CharacterDelimiter;
        public string DatabaseStoredProcedureName;
        public Settings Settings;
        public List<Header> Headers;
        public List<Column> Columns;
        public List<Footer> Footers;

        public FileType()
        {

        }

        public FileType(string Name, string Delimiter, string DatabaseStoredProcedureName)
        {
            this.Name = Name;
            this.Delimiter = Delimiter;
            this.DatabaseStoredProcedureName = DatabaseStoredProcedureName;
        }

        public FileType(int FileTypeID, string Name, string Delimiter, string DatabaseStoredProcedureName)
        {
            this.FileTypeID = FileTypeID;
            this.Name = Name;

            if (Delimiter.Contains(@"\t"))
            {
                this.Delimiter = Delimiter;
                CharacterDelimiter = Convert.ToChar('\t');
            }
            else
            {
                this.Delimiter = Delimiter;
                CharacterDelimiter = Convert.ToChar(Delimiter);
            }

            this.DatabaseStoredProcedureName = DatabaseStoredProcedureName;
        }
    }
}
