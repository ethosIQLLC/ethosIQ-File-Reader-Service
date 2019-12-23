using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class Header
    {
        public int FileTypeID;
        public int HeaderNumber;
        public string HeaderName;
        public string HeaderData;


        public Header()
        {

        }

        public Header(int HeaderNumber, string HeaderName)
        {
            this.HeaderNumber = HeaderNumber;
            this.HeaderName = HeaderName;
        }

        public Header(int FileTypeID, int HeaderNumber, string HeaderName)
        {
            this.FileTypeID = FileTypeID;
            this.HeaderNumber = HeaderNumber;
            this.HeaderName = HeaderName;
        }

        public void AddHeaderData(string HeaderData)
        {
            this.HeaderData = HeaderData;
        }
    }
}
