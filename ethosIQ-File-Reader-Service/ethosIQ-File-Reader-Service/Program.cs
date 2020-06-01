using ethosIQ_Configuration;
using ethosIQ_Database;
using ethosIQ_File_Reader_Shared.DAO;
using ethosIQ_File_Reader_Shared.FileConfig;
using ethosIQ_File_Reader_Shared.Installation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ethosIQ_File_Reader_Service
{
    [System.ServiceModel.ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    public class Program : ServiceBase
    {
        public FileSourceController controller;

        static void Main(string[] args)
        {

            ServiceHost serviceHost;
            Program service = new Program();
            if (Environment.UserInteractive)
            {
                
                serviceHost = new ServiceHost(service);
                
                Database ConfigurationDatabase = null;
                try
                {
                    ConfigurationDatabase = LocalConfigurationDatabase.GetConfigurationDatabase();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Failed to get configuration database. " + exception.Message);
                }

                if(ConfigurationDatabase != null)
                {
                    FileTypeTableInstallation.CreateFileTypeTable(ConfigurationDatabase);
                    ColumnTableInstallation.CreateColumnTable(ConfigurationDatabase);
                    FooterTableInstallation.CreateFooterTable(ConfigurationDatabase);
                    HeaderTableInstallation.CreateHeaderTable(ConfigurationDatabase);
                    SettingsTableInstallation.CreateSettingsTable(ConfigurationDatabase);
                    FileSourceTableInstallation.CreateFileSourceTable(ConfigurationDatabase);
                    Console.WriteLine("Installed tables!");
                }
                else
                {
                    Console.WriteLine("Failed to install tables.");
                }

                serviceHost.Open();
                service.OnStart(args);

                Console.ReadLine();

            }
            else
            {
                serviceHost = new ServiceHost(service);
                serviceHost.Open();
                Run(service);
            }
        }

        protected override void OnStart(string[] args)
        {
            controller = new FileSourceController();
            controller.StartSources();

            Console.WriteLine("ethosIQ File Reader Service started!");
        }

        protected override void OnStop()
        {
            controller.StopSources();
        }
    }
}
