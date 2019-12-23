using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class Footer
    {
        public int FileTypeID;
        public int FooterNumber;
        public string FooterName;

        public Footer()
        {

        }

        public Footer(int FooterNumber, string FooterName)
        {
            this.FooterNumber = FooterNumber;
            this.FooterName = FooterName;
        }

        public Footer(int FileTypeID, int FooterNumber, string FooterName)
        {
            this.FileTypeID = FileTypeID;
            this.FooterNumber = FooterNumber;
            this.FooterName = FooterName;
        }
    }
}
