using ethosIQ_Configuration;
using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.Installation;
using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ethosIQ_File_Reader_Service
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        private Database ConfigurationDatabase;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "ethosIQ-File-Reader-Service";
            Installers.Add(process);
            Installers.Add(service);

            try
            {
                ConfigurationDatabase = LocalConfigurationDatabase.GetConfigurationDatabase();
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed to get configuration database information. " + exception.Message);
            }

            if(ConfigurationDatabase != null)
            {
                FooterTableInstallation.CreateFooterTable(ConfigurationDatabase);
                Console.WriteLine("Created footer table.");

                SettingsTableInstallation.CreateSettingsTable(ConfigurationDatabase);
                Console.WriteLine("Created file settings table.");

                ColumnTableInstallation.CreateColumnTable(ConfigurationDatabase);
                Console.WriteLine("Created column table.");

                FileSourceTableInstallation.CreateFileSourceTable(ConfigurationDatabase);
                Console.WriteLine("Created file source table.");

                HeaderTableInstallation.CreateHeaderTable(ConfigurationDatabase);
                Console.WriteLine("Created header table.");

                FileTypeTableInstallation.CreateFileTypeTable(ConfigurationDatabase);
                Console.WriteLine("Created file type table.");

                CollectionDatabaseInstallation.CreateCollectionDatabaseTable(ConfigurationDatabase);
                Console.WriteLine("Created collection database table");
            }

        }
    }
}
