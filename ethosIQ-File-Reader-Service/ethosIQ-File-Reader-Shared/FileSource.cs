using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.DAO;
using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Shared
{
    public class FileSource
    {
        public int FileSourceID;
        public string Name;
        public string Directory;
        public int FileTypeID;
        public FileType FileType;
        public int DateTimeErrorCount, TruncateTableErrorCount, ProcessRowErrorCount, InsertRowErrorCount;

        private EventLog eventLog;
        private FileSystemWatcher FileSystemWatcher;
        private Database ConfigurationDatabase;
        private Database CollectionDatabase;

        public FileSource()
        {

        }

        public FileSource(int FileSourceID, string Name, string Directory)
        {
            this.FileSourceID = FileSourceID;
            this.Name = Name;
            this.Directory = Directory;
        }

        public FileSource(int FileSourceID, int FileTypeID, string Name, string Directory)
        {
            this.FileSourceID = FileSourceID;
            this.FileTypeID = FileTypeID;
            this.Name = Name;
            this.Directory = Directory;
        }

        public void AddFileTypeID(int FileTypeID)
        {
            this.FileTypeID = FileTypeID;
        }

        public void AddConfigurationDatabase(Database ConfigurationDatabase)
        {
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        public void AddCollectionDatabase(Database CollectionDatabase)
        {
            this.CollectionDatabase = CollectionDatabase;
        }

        public void Start()
        {
            try
            {
                if (!EventLog.SourceExists(Name))
                {
                    EventLog.CreateEventSource(Name, "File Reader Service");
                }

                eventLog = new EventLog();

                eventLog.Log = "File Reader Service";
                eventLog.Source = Name;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to setup event viewer logging. " + exception.Message);
            }

            try
            {
                if (ConfigurationDatabase != null)
                {
                    FileTypeDAO fileTypeDAO = new FileTypeDAO(ConfigurationDatabase);
                    FileType = fileTypeDAO.GetFileType(FileTypeID);

                    SettingsDAO settingsDAO = new SettingsDAO(ConfigurationDatabase);
                    FileType.Settings = settingsDAO.GetSettingsByFileTypeID(FileTypeID);

                    ColumnDAO columnDAO = new ColumnDAO(ConfigurationDatabase);
                    FileType.Columns = columnDAO.Read(FileTypeID);

                    HeaderDAO headerDAO = new HeaderDAO(ConfigurationDatabase);
                    FileType.Headers = headerDAO.GetHeadersByFileTypeID(FileTypeID);

                    FooterDAO footerDAO = new FooterDAO(ConfigurationDatabase);
                    FileType.Footers = footerDAO.GetFootersByFileTypeID(FileTypeID);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to get file type information from configuration database. " + exception.Message);

                if (eventLog != null)
                {
                    eventLog.WriteEntry("Failed to get file type information from configuration database. " + exception.Message, EventLogEntryType.Error);
                }
            }

            try
            {
                FileSystemWatcher = new FileSystemWatcher(Directory, "*.*");
                FileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
                FileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
                FileSystemWatcher.EnableRaisingEvents = true;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to setup file system watcher. " + exception.Message);

                if(eventLog != null)
                {
                    eventLog.WriteEntry("Failed to setup file system watcher. " + exception.Message, EventLogEntryType.Error);
                }
            }
        }

        public void Stop()
        {

        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //FileSystemWatcher.EnableRaisingEvents = false;

            foreach (string FullPath in System.IO.Directory.GetFiles(Path.GetDirectoryName(e.FullPath)))
            {
                try
                {
                    while (!IsFileReady(System.IO.Directory.GetFiles(Path.GetDirectoryName(e.FullPath)).ToList()))
                    {
                        Thread.Sleep(2000);
                    }

                    DateTime FileNameDateTime = new DateTime();
                    DateTime FileExtensionDateTime = new DateTime();
                    DateTime ActualDateTime = new DateTime();

                    Console.WriteLine("Checking File name and extensions...");
                    try
                    {
                        if (FileType.Settings.UseFileName && !FileType.Settings.UseFileExtension)
                        {
                            ActualDateTime = DateTime.ParseExact(Path.GetFileNameWithoutExtension(FullPath).Replace(FileType.Settings.TextToIgnoreFileName, ""), FileType.Settings.DateTimeFormatFileName, CultureInfo.InvariantCulture);
                        }
                        if (FileType.Settings.UseFileExtension && !FileType.Settings.UseFileName)
                        {
                            ActualDateTime = DateTime.ParseExact(Path.GetExtension(FullPath).Replace(FileType.Settings.TextToIgnoreFileName, ""), FileType.Settings.DateTimeFormatFileExtension, CultureInfo.InvariantCulture);
                        }
                        if (FileType.Settings.UseFileName && FileType.Settings.UseFileExtension)
                        {
                            FileNameDateTime = DateTime.ParseExact(Path.GetFileNameWithoutExtension(FullPath).Replace(FileType.Settings.TextToIgnoreFileName, ""), FileType.Settings.DateTimeFormatFileName, CultureInfo.InvariantCulture);
                            FileExtensionDateTime = DateTime.ParseExact(Path.GetExtension(FullPath).Replace(FileType.Settings.TextToIgnoreFileName, ""), FileType.Settings.DateTimeFormatFileExtension, CultureInfo.InvariantCulture);
                            ActualDateTime = new DateTime(FileNameDateTime.Year, FileNameDateTime.Month, FileNameDateTime.Day, FileExtensionDateTime.Hour, FileExtensionDateTime.Minute, FileExtensionDateTime.Second);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Failed to get a DateTime from file. " + exception.Message);
                        DateTimeErrorCount++;

                       /* if (eventLog != null)
                        {
                            eventLog.WriteEntry("Failed to get a DateTime from file. " + exception.Message, EventLogEntryType.Error);
                        } */
                    }

                    if (FileType.Settings.TruncateTable)
                    {
                        try
                        {
                            DataDAO dataDAO = new DataDAO(CollectionDatabase);
                            dataDAO.TruncateTable(FileType.DatabaseStoredProcedureName);
                            eventLog.WriteEntry("Successfully truncated table " + FileType.DatabaseStoredProcedureName + ".", EventLogEntryType.Information);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine("Failed to truncate table " + FileType.DatabaseStoredProcedureName + ". " + exception.Message);
                            TruncateTableErrorCount++;
                           /* if (eventLog != null)
                            {
                                eventLog.WriteEntry("Failed to truncate table " + FileType.DatabaseStoredProcedureName + ". " + exception.Message, EventLogEntryType.Error);
                            } */
                        }
                    }

                    string[] AllRowsInFile = File.ReadAllLines(FullPath);

                    if(AllRowsInFile.Count() > 0)
                    {
                        string[] DataRows = AllRowsInFile.Skip(FileType.Headers.Count).ToArray();

                        foreach (string DataLine in DataRows)
                        {
                            int index = 0;

                            string[] Data = DataLine.Split(FileType.CharacterDelimiter);

                            foreach (Column column in FileType.Columns.OrderBy(x => x.ColumnNumber))
                            {
                                try
                                {
                                    if (!column.Ignore)
                                    {
                                        if (FileType.Settings.LinkDateTime && FileType.Settings.DateTimeColumn == column.ColumnName)
                                        {
                                            DateTime linkedDate = DateTime.ParseExact(Data[index], FileType.Settings.DateTimeFormatLinkDate, CultureInfo.InvariantCulture);

                                            if (linkedDate != null)
                                            {
                                                column.ColumnData = linkedDate;
                                            }

                                            //column.ColumnData = ActualDateTime;
                                        }
                                        else
                                        {
                                            column.ColumnData = Data[index];
                                        }
                                        if (!column.NotInFile)
                                        {
                                            index++;
                                        }
                                    }
                                    else //Added
                                    {
                                        index++;
                                    }
                                }
                                catch(Exception exception)
                                {
                                    Console.WriteLine("Failed to process row: " + DataLine + " - " + exception.Message);
                                    ProcessRowErrorCount++;
                                  /*  if (eventLog != null)
                                    {
                                        eventLog.WriteEntry("Failed to process row: LinkDate Format: " + FileType.Settings.DateTimeFormatLinkDate + ": " + DataLine + " - " + exception.Message, EventLogEntryType.Error);
                                    } */
                                }
                            }

                            if (CollectionDatabase != null)
                            {
                                try
                                {
                                    DataDAO dataDAO = new DataDAO(CollectionDatabase);
                                    string debugData = "";

                                    /*
                                    foreach(Column column in FileType.Columns)
                                    {
                                        debugData += column.ColumnNumber + ":" + column.ColumnName + ":" + column.DatabaseColumnName + ":" + column.ColumnData + "\n";
                                    }
                                    */
                                    //eventLog.WriteEntry("Attempting data: " + debugData, EventLogEntryType.Warning);

                                    dataDAO.Insert(FileType.DatabaseStoredProcedureName, FileType.Columns);
                                    
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine("Failed to insert row: " + DataLine + " - " + exception.Message);
                                    InsertRowErrorCount++;
                                   /* if (eventLog != null)
                                    {
                                        eventLog.WriteEntry("Failed to insert row: " + DataLine + " - " + exception.Message, EventLogEntryType.Error);
                                    } */
                                }
                            }
                        }
                    }

                    Console.WriteLine("Successfully processed file: " + FullPath + "!. Processed " + AllRowsInFile.Count() + " rows.");

                    if (eventLog != null)
                    {
                        eventLog.WriteEntry("Successfully processed file: " + FullPath + "! Processed " + AllRowsInFile.Count() + " rows.", EventLogEntryType.Information);
                        int totalErrorCount = DateTimeErrorCount + TruncateTableErrorCount + ProcessRowErrorCount + InsertRowErrorCount;

                        if (totalErrorCount > 0)
                        {
                            eventLog.WriteEntry("Encountered "+ totalErrorCount + " errors while processing file: " + FullPath + ". " + DateTimeErrorCount 
                                + " failure(s) to get a DateTime, " + TruncateTableErrorCount + " failure(s) to truncate tables, " + ProcessRowErrorCount + " failure(s) to process rows, and " +
                                InsertRowErrorCount + " failure(s) to insert rows.", EventLogEntryType.Error);
                          
                            
                        }
                      

                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Failed to process file: " + FullPath + ". " + exception.Message);

                    if (eventLog != null)
                    {
                        eventLog.WriteEntry("Failed to process file: " + FullPath + ". " + exception.Message, EventLogEntryType.Error);
                    }
                }

                try
                {
                    if (File.Exists(Path.GetDirectoryName(FullPath) + @"\Processed\" + Path.GetFileName(FullPath)))
                    {
                        File.Delete(Path.GetDirectoryName(FullPath) + @"\Processed\" + Path.GetFileName(FullPath));
                        File.Move(FullPath, Path.GetDirectoryName(FullPath) + @"\Processed\" + Path.GetFileName(FullPath));
                    }
                    else
                    {
                        File.Move(FullPath, Path.GetDirectoryName(FullPath) + @"\Processed\" + Path.GetFileName(FullPath));
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Failed to move file to Processed folder: " + FullPath + ". " + exception.Message);

                    if (eventLog != null)
                    {
                        eventLog.WriteEntry("Failed to move file to Processed folder: " + FullPath + ". " + exception.Message, EventLogEntryType.Error);
                    }
                }
            }

            //FileSystemWatcher.EnableRaisingEvents = true;
        }

        private static bool IsFileReady(List<string> FileNames)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                foreach (string filename in FileNames)
                {
                    using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                        return true;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
