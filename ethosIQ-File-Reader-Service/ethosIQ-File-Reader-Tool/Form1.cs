using ethosIQ_Configuration;
using ethosIQ_Database;
using ethosIQ_File_Reader_Shared;
using ethosIQ_File_Reader_Shared.DAO;
using ethosIQ_File_Reader_Tool.FileTypeModal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ethosIQ_File_Reader_Tool
{
    public partial class Form1 : Form
    {
        private Database CollectionDatabase;
        private Database ConfigurationDatabase;
        private List<FileSource> FileSources;
        private List<FileType> FileTypes;

        private EventLog eventLog;

        public Form1()
        {
            InitializeComponent();
            loadConfigurationWorker.RunWorkerAsync();
        }

        private void loadConfigurationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!EventLog.SourceExists("File Reader Tool"))
            {
                EventLog.CreateEventSource("File Reader Tool", "eIQ-File-Reader-Service");
            }

            eventLog = new EventLog();
            eventLog.Log = "eIQ-File-Reader-Service";
            eventLog.Source = "File Reader Tool";

            try
            {
                ConfigurationDatabase = LocalConfigurationDatabase.GetConfigurationDatabase();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Configuration Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ConfigurationDatabase != null)
            {
                try
                {
                    CollectionDatabaseConfiguration collectionDatabaseConfiguration = new CollectionDatabaseConfiguration(ConfigurationDatabase);
                    CollectionDatabase = collectionDatabaseConfiguration.GetCollectionDatabase();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Collection Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (CollectionDatabase != null)
                {
                    try
                    {
                        CollectionDatabase.CreateOpenConnection();
                        connectedLabel.Invoke(new Action(() => connectedLabel.Text = "Connected"));
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Collection Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (CollectionDatabase != null)
                {
                    databaseTypeTextBox.Invoke(new Action(() => databaseTypeTextBox.Text = CollectionDatabase.DatabaseType.ToString()));
                    dataSourceTextBox.Invoke(new Action(() => dataSourceTextBox.Text = CollectionDatabase.DataSource));
                    hostTextBox.Invoke(new Action(() => hostTextBox.Text = CollectionDatabase.Host));
                    portTextBox.Invoke(new Action(() => portTextBox.Text = CollectionDatabase.Port.ToString()));
                    usernameTextBox.Invoke(new Action(() => usernameTextBox.Text = CollectionDatabase.Username));
                    passwordTextBox.Invoke(new Action(() => passwordTextBox.Text = CollectionDatabase.Password));
                }

                try
                {
                    FileTypeDAO fileTypeDAO = new FileTypeDAO(ConfigurationDatabase);
                    FileTypes = fileTypeDAO.GetAllFileTypes();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to get File Type Configuration. " + exception.Message, "File Type Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (FileTypes != null)
                {
                    try
                    {
                        foreach (FileType fileType in FileTypes)
                        {
                            fileTypeGridView.Invoke(new Action(() => fileTypeGridView.Rows.Add(fileType.FileTypeID.ToString(), fileType.Name, fileType.Delimiter, fileType.DatabaseStoredProcedureName)));
                        }
                    }
                    catch (Exception exception)
                    {

                    }
                }

                try
                {
                    FileSourceDAO fileSourceDAO = new FileSourceDAO(ConfigurationDatabase);
                    FileSources = fileSourceDAO.GetAllFileSources();
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Failed to get File Source Configuration. " + exception.Message, "File Source Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (FileSources != null)
                {
                    try
                    {
                        foreach (FileSource fileSource in FileSources)
                        {
                            fileSourceGridView.Invoke(new Action(() => fileSourceGridView.Rows.Add(fileSource.FileTypeID.ToString(), fileSource.Name.ToString(), fileSource.Directory.ToString())));
                        }
                    }
                    catch (Exception exception)
                    {

                    }
                }
            }
        }

        private void addFileSourceButton_Click(object sender, EventArgs e)
        {
            using (AddFileSourceModal addFileSourceModal = new AddFileSourceModal(ref fileSourceGridView, ConfigurationDatabase))
            {
                addFileSourceModal.ShowDialog();
            }
        }

        private void checkDatabaseConnectionButton_Click(object sender, EventArgs e)
        {
            if (!checkCollectionDatabaseConnectionWorker.IsBusy)
            {
                checkCollectionDatabaseConnectionWorker.RunWorkerAsync();
            }
        }

        private void checkCollectionDatabaseConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CollectionDatabaseConfiguration collectionDatabaseConfiguration = new CollectionDatabaseConfiguration();

                CollectionDatabase = collectionDatabaseConfiguration.GetCollectionDatabaseManually(databaseTypeTextBox.Text,
                                                                                                   dataSourceTextBox.Text,
                                                                                                   hostTextBox.Text,
                                                                                                   Convert.ToInt32(portTextBox.Text),
                                                                                                   usernameTextBox.Text,
                                                                                                   passwordTextBox.Text);
            }
            catch (Exception exception)
            {
                connectedLabel.Text = "Disconnected";
                MessageBox.Show(exception.Message, "Collection Database Manual Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CollectionDatabase != null)
            {
                try
                {
                    using (IDbConnection connection = CollectionDatabase.CreateOpenConnection())
                    {

                    }

                    connectedLabel.Invoke(new Action(() => connectedLabel.Text = "Connected"));
                }
                catch (Exception exception)
                {
                    connectedLabel.Invoke(new Action(() => connectedLabel.Text = "Disconnected"));
                    MessageBox.Show(exception.Message, "Collection Database Manual Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addFileTypeButton_Click(object sender, EventArgs e)
        {
            using (CreateFileTypeModal createFileTypeModal = new CreateFileTypeModal(ref fileTypeGridView, ConfigurationDatabase))
            {
                createFileTypeModal.ShowDialog();
            }
        }

        private void editFileTypeButton_Click(object sender, EventArgs e)
        {
            int fileTypeID = Convert.ToInt32(fileTypeGridView.CurrentRow.Cells["FileTypeID"].Value);

            using (EditFileTypeModal editFileTypeModal = new EditFileTypeModal(ConfigurationDatabase, fileTypeID))
            {
                editFileTypeModal.ShowDialog();
            }
        }

        private void removeFileSourceButton_Click(object sender, EventArgs e)
        {
            string fileSourceName;
            DataGridViewRow fileSourceRow;

            if (fileSourceGridView.Rows.Count > 0)
            {
                fileSourceRow = fileSourceGridView.CurrentRow;

                fileSourceName = fileSourceRow.Cells["columnName"].Value.ToString();

                try
                {
                    FileSourceDAO fileSourceDAO = new FileSourceDAO(ConfigurationDatabase);
                    fileSourceDAO.Delete(fileSourceName);

                    FileSources = fileSourceDAO.GetAllFileSources();

                    if (FileSources != null)
                    {
                        fileSourceGridView.Rows.Remove(fileSourceRow);
                        fileSourceGridView.Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to remove File Source. " + exception.Message, "File Source Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeFileTypeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this File Type?", "Remove File Type", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                int fileTypeID;

                DataGridViewRow fileTypeRow;

                if (fileTypeGridView.Rows.Count > 0)
                {
                    fileTypeRow = fileTypeGridView.CurrentRow;

                    fileTypeID = Convert.ToInt32(fileTypeRow.Cells["fileTypeID"].Value);

                    try
                    {
                        FileTypeDAO fileTypeDAO = new FileTypeDAO(ConfigurationDatabase);
                        fileTypeDAO.Delete(fileTypeID);

                        SettingsDAO settingsDAO = new SettingsDAO(ConfigurationDatabase);
                        settingsDAO.Delete(fileTypeID);

                        ColumnDAO columnDAO = new ColumnDAO(ConfigurationDatabase);
                        columnDAO.DeleteAll(fileTypeID);

                        HeaderDAO headerDAO = new HeaderDAO(ConfigurationDatabase);
                        headerDAO.DeleteAll(fileTypeID);

                        FooterDAO footerDAO = new FooterDAO(ConfigurationDatabase);
                        footerDAO.DeleteAll(fileTypeID);

                        FileTypes = fileTypeDAO.GetAllFileTypes();

                        if (FileTypes != null)
                        {
                            fileTypeGridView.Rows.Remove(fileTypeRow);
                            fileTypeGridView.Refresh();
                        }


                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Failed to remove File Source. " + exception.Message, "File Source Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
