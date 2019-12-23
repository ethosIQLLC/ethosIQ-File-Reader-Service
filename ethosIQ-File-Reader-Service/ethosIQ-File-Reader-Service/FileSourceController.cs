using ethosIQ_Configuration;
using ethosIQ_Database;
using ethosIQ_File_Reader_Shared;
using ethosIQ_File_Reader_Shared.Configuration;
using ethosIQ_File_Reader_Shared.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Service
{
    public class FileSourceController
    {
        public EventLog eventLog;
        public List<FileSource> FileSources;
        public Database ConfigurationDatabase;
        public Database CollectionDatabase;

        public FileSourceController()
        {
            try
            {
                if (!EventLog.SourceExists("File Source Controller"))
                {
                    EventLog.CreateEventSource("File Source Controller", "File-Reader-Service");
                }

                eventLog = new EventLog();

                eventLog.Log = "File-Reader-Service";
                eventLog.Source = "File Source Controller";
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to setup event viewer logging. " + exception.Message);
            }
        }

        public void StartSources()
        {
            try
            {
                ConfigurationDatabase = LocalConfigurationDatabase.GetConfigurationDatabase();
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to get configuration database. " + exception.Message);

                if (eventLog != null)
                {
                    eventLog.WriteEntry("Failed to get configuration database. " + exception.Message, EventLogEntryType.Error);
                }
            }

            try
            {
                if (ConfigurationDatabase != null)
                {
                    CollectionDatabaseConfiguration collectionDatabaseConfiguration = new CollectionDatabaseConfiguration(ConfigurationDatabase);
                    CollectionDatabase = collectionDatabaseConfiguration.GetCollectionDatabase();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to get collection database. " + exception.Message);

                if (eventLog != null)
                {
                    eventLog.WriteEntry("Failed to get collection database. " + exception.Message, EventLogEntryType.Error);
                }
            }

            try
            {
                FileSources = GetFileSources();

                if(FileSources != null)
                {
                    foreach(FileSource fileSource in FileSources)
                    {
                        fileSource.AddCollectionDatabase(CollectionDatabase);
                        fileSource.AddConfigurationDatabase(ConfigurationDatabase);
                        fileSource.Start();
                    }
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to get file source information from configuration database. " + exception.Message);

                if (eventLog != null)
                {
                    eventLog.WriteEntry("Failed to get file source information from configuration database. " + exception.Message, EventLogEntryType.Error);
                }
            }
        }

        public void StopSources()
        {
            try
            {
                if (FileSources != null)
                {
                    foreach (FileSource fileSource in FileSources)
                    {
                        fileSource.Stop();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to stop service. " + exception.Message);

                if (eventLog != null)
                {
                    eventLog.WriteEntry("Failed to stop service. " + exception.Message, EventLogEntryType.Error);
                }
            }
        }

        private List<FileSource> GetFileSources()
        {
            if(ConfigurationDatabase != null)
            {
                FileSourceDAO fileSourceDAO = new FileSourceDAO(ConfigurationDatabase);

                return fileSourceDAO.GetAllFileSources();
            }

            return null;
        }
    }
}
