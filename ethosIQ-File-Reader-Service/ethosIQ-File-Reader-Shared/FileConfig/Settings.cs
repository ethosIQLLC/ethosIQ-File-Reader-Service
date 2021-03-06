﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared.FileConfig
{
    public class Settings
    {
        public int FileTypeID;
        public bool UseFileName;
        public bool UseFileExtension;
        public string TextToIgnoreFileName;
        public string DateTimeFormatFileName;
        public string TextToIgnoreFileExtension;
        public string DateTimeFormatFileExtension;

        public bool LinkDateTime;
        public string DateTimeFormatLinkDate;
        public string DateTimeColumn;

        public bool TruncateTable;

        public Settings()
        {

        }

        public Settings(int FileTypeID, bool UseFileName, bool UseFileExtension, string TextToIgnoreFileName, string DateTimeFormatFileName, string TextToIgnoreFileExtension, string DateTimeFormatFileExtension, bool LinkDateTime, string DateTimeColumn, string DateTimeFormatLinkDate, bool TruncateTable)
        {
            this.FileTypeID = FileTypeID;
            this.UseFileName = UseFileName;
            this.UseFileExtension = UseFileExtension;
            this.TextToIgnoreFileName = TextToIgnoreFileName;
            this.DateTimeFormatFileName = DateTimeFormatFileName;
            this.TextToIgnoreFileExtension = TextToIgnoreFileExtension;
            this.DateTimeFormatFileExtension = DateTimeFormatFileExtension;
            this.LinkDateTime = LinkDateTime;
            this.DateTimeColumn = DateTimeColumn;
            this.TruncateTable = TruncateTable;
            this.DateTimeFormatLinkDate = DateTimeFormatLinkDate;
        }
    }
}
