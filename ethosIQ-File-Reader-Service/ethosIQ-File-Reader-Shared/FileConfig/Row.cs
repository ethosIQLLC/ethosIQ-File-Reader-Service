using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class Row
    {
        List<string> RowData;

        public Row()
        {
            RowData = new List<string>();
        }

        public void AddDataToRow(string Data)
        {
            if(Data != null)
            {
                RowData.Add(Data);
            }
        }
    }
}
