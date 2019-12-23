using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class DataFile
    {
        public string FullFilePath;
        public string FileName;
        public string FileExtension;
        public string Delimiter;
        public List<Header> Headers;
        public List<Column> Columns;
        public List<Row> Rows;
        public List<Footer> Footers;

        public DataFile(string FullFilePath, string FileName, string FileExtension, string Delimiter, List<Header> Headers, List<Column> Columns, List<Footer> Footers)
        {
            this.FullFilePath = FullFilePath;
            this.FileName = FileName;
            this.FileExtension = FileExtension;
            this.Delimiter = Delimiter;
            this.Headers = Headers;
            this.Columns = Columns;
            this.Footers = Footers;

            Rows = new List<Row>();
        }

        public void ReadFileData()
        {
            int SkipableLines = 0;

            if(Headers != null)
            {
                SkipableLines += Headers.Count;
            }

            if(Columns != null)
            {
                SkipableLines += 1;
            }

            try
            {
                string[] AllLinesInFile = File.ReadAllLines(FullFilePath);

                for(int numDataLines = SkipableLines; numDataLines < AllLinesInFile.Count(); numDataLines++)
                {
                    Row tempRow = new Row();

                    string[] delimitedLine = AllLinesInFile.ElementAt(numDataLines).Split(Convert.ToChar(Delimiter));

                    foreach(string data in delimitedLine)
                    {
                        tempRow.AddDataToRow(data);
                    }

                    Rows.Add(tempRow);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            
        }
    }
}
