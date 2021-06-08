using ethosIQ_Database;
using ethosIQ_File_Reader_Shared;
using ethosIQ_File_Reader_Shared.DAO;
using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    public partial class EditFileTypeModal : Form
    {
        private int FileTypeID;
        public FileType FileType;
        public List<Header> Headers;
        public List<Footer> Footers;
        public List<Column> Columns;
        public Settings Settings;
        public Database ConfigurationDatabase;

        public EditFileTypeModal(Database ConfigurationDatabase, int FileTypeID)
        {
            InitializeComponent();
            this.ConfigurationDatabase = ConfigurationDatabase;
            this.FileTypeID = FileTypeID;
            loadEditFileTypeWorker.RunWorkerAsync();
        }

        private void loadEditFileTypeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ConfigurationDatabase != null)
            {
                try
                {
                    FileTypeDAO fileTypeDAO = new FileTypeDAO(ConfigurationDatabase);

                    FileType = fileTypeDAO.GetFileType(FileTypeID);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to get File Type data. " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(FileType != null)
                {
                    fileTypeIDTextBox.Invoke(new Action(() => fileTypeIDTextBox.Text = FileType.FileTypeID.ToString()));
                    nameTextBox.Invoke(new Action(() => nameTextBox.Text = FileType.Name));
                    delimiterTextBox.Invoke(new Action(() => delimiterTextBox.Text = FileType.Delimiter.ToString()));
                    storedProcedureTextBox.Invoke(new Action(() => storedProcedureTextBox.Text = FileType.DatabaseStoredProcedureName));

                    headerGroupBox.Invoke(new Action(() => headerGroupBox.Enabled = true));
                    footerGroupBox.Invoke(new Action(() => footerGroupBox.Enabled = true));
                    columnGroupBox.Invoke(new Action(() => columnGroupBox.Enabled = true));
                    settingsGroupBox.Invoke(new Action(() => settingsGroupBox.Enabled = true));

                    try
                    {
                        SettingsDAO settingsDAO = new SettingsDAO(ConfigurationDatabase);
                        Settings = settingsDAO.GetSettingsByFileTypeID(FileTypeID);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show("Failed to get Settings data. " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if(Settings != null)
                    {
                        useFileNameCheckBox.Invoke(new Action(() => useFileNameCheckBox.Checked = Settings.UseFileName));
                        useFileExtensionCheckBox.Invoke(new Action(() => useFileExtensionCheckBox.Checked = Settings.UseFileExtension));
                        textToIgnoreFileNameTextBox.Invoke(new Action(() => textToIgnoreFileNameTextBox.Text = Settings.TextToIgnoreFileName));
                        dateTimeFormatFileNameTextBox.Invoke(new Action(() => dateTimeFormatFileNameTextBox.Text = Settings.DateTimeFormatFileName));
                        textToIgnoreFileExtensionTextBox.Invoke(new Action(() => textToIgnoreFileExtensionTextBox.Text = Settings.TextToIgnoreFileExtension));
                        dateTimeFormatFileExtensionTextBox.Invoke(new Action(() => dateTimeFormatFileExtensionTextBox.Text = Settings.DateTimeFormatFileExtension));
                        linkDateTimeCheckBox.Invoke(new Action(() => linkDateTimeCheckBox.Checked = Settings.LinkDateTime));
                        dateTimeColumnTextBox.Invoke(new Action(() => dateTimeColumnTextBox.Text = Settings.DateTimeColumn));
                        dateTimeFormatLinkDateTextBox.Invoke(new Action(() => dateTimeFormatLinkDateTextBox.Text = Settings.DateTimeFormatLinkDate));
                        truncateTableCheckBox.Invoke(new Action(() => truncateTableCheckBox.Checked = Settings.TruncateTable));
                    }

                    try
                    {
                        HeaderDAO headerDAO = new HeaderDAO(ConfigurationDatabase);
                        Headers = headerDAO.GetHeadersByFileTypeID(FileTypeID);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show("Failed to get Header data. " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if(Headers != null)
                    {
                        foreach(Header header in Headers)
                        {
                            headerDataGridView.Invoke(new Action(() => headerDataGridView.Rows.Add(header.HeaderNumber.ToString(), header.HeaderName)));
                        }
                    }

                    try
                    {
                        ColumnDAO columnDAO = new ColumnDAO(ConfigurationDatabase);
                        Columns = columnDAO.Read(FileTypeID);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show("Failed to get Column data. " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if(Columns != null)
                    {
                        foreach (Column column in Columns)
                        {
                            columnDataGridView.Invoke(new Action(() => columnDataGridView.Rows.Add(column.ColumnNumber.ToString(), column.ColumnName, column.DatabaseColumnName, column.Ignore, column.NotInFile)));
                        }
                    }
                }
            }
        }

        private void saveFileTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsDAO settingsDAO = new SettingsDAO(ConfigurationDatabase);
                settingsDAO.Delete(FileTypeID);

                settingsDAO.Insert(new Settings(FileTypeID, useFileNameCheckBox.Checked, useFileExtensionCheckBox.Checked, textToIgnoreFileNameTextBox.Text, dateTimeFormatFileNameTextBox.Text, textToIgnoreFileExtensionTextBox.Text, dateTimeFormatFileExtensionTextBox.Text, linkDateTimeCheckBox.Checked, dateTimeColumnTextBox.Text, dateTimeFormatLinkDateTextBox.Text, truncateTableCheckBox.Checked));

                ColumnDAO columnDAO = new ColumnDAO(ConfigurationDatabase);
                columnDAO.DeleteAll(FileTypeID);

                foreach (DataGridViewRow row in columnDataGridView.Rows)
                {
                    columnDAO.Insert(new Column(FileTypeID, Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), Convert.ToBoolean(row.Cells[3].Value), Convert.ToBoolean(row.Cells[4].Value)));
                }

                HeaderDAO headerDAO = new HeaderDAO(ConfigurationDatabase);
                headerDAO.DeleteAll(FileTypeID);

                foreach (DataGridViewRow row in headerDataGridView.Rows)
                {
                    headerDAO.Insert(new Header(FileTypeID, Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString()));
                }

                FooterDAO footerDAO = new FooterDAO(ConfigurationDatabase);
                footerDAO.DeleteAll(FileTypeID);

                foreach (DataGridViewRow row in footerDataGridView.Rows)
                {
                    footerDAO.Insert(new Footer(FileTypeID, Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString()));
                }

                MessageBox.Show("Successfully saved File Type Configuration!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Failed to save Column data. " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------HEADER BUTTONS----------------
        private void addHeaderButton_Click(object sender, EventArgs e)
        {
            using (AddHeaderModal addHeaderModal = new AddHeaderModal(ref headerDataGridView))
            {
                addHeaderModal.ShowDialog();
            }
        }

        private void removeHeaderButton_Click(object sender, EventArgs e)
        {
            int headerNumber = 0;

            DataGridViewRow headerRow;

            if (headerDataGridView.Rows.Count > 0)
            {
                headerRow = headerDataGridView.CurrentRow;

                headerNumber = Convert.ToInt32(headerRow.Cells["headerNumber"].Value);

                try
                {
                    HeaderDAO headerDAO = new HeaderDAO(ConfigurationDatabase);
                    headerDAO.Delete(FileTypeID, headerNumber);

                    Headers = headerDAO.GetHeadersByFileTypeID(FileTypeID);

                    if (Headers != null)
                    {
                        headerDataGridView.Rows.Remove(headerRow);

                        foreach (DataGridViewRow row in headerDataGridView.Rows)
                        {
                            row.Cells["headerNumber"].Value = row.Cells["headerNumber"].RowIndex;
                        }

                        headerDataGridView.Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to remove Header. " + exception.Message, "Header Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //----------------COLUMN BUTTONS----------------
        private void addColumnButton_Click(object sender, EventArgs e)
        {
            using (AddColumnModal addColumnModal = new AddColumnModal(ref columnDataGridView))
            {
                addColumnModal.ShowDialog();
            }
        }

        private void removeColumnButton_Click(object sender, EventArgs e)
        {
            int columnNumber = 0;

            DataGridViewRow columnRow;

            if (columnDataGridView.Rows.Count > 0)
            {
                columnRow = columnDataGridView.CurrentRow;

                columnNumber = Convert.ToInt32(columnRow.Cells["columnNumber"].Value);

                try
                {
                    ColumnDAO columnDAO = new ColumnDAO(ConfigurationDatabase);
                    columnDAO.Delete(FileTypeID, columnNumber);

                    Columns = columnDAO.Read(FileTypeID);

                    if (Columns != null)
                    {
                        columnDataGridView.Rows.Remove(columnRow);

                        foreach (DataGridViewRow row in columnDataGridView.Rows)
                        {
                            row.Cells["columnNumber"].Value = row.Cells["columnNumber"].RowIndex;
                        }

                        columnDataGridView.Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to remove Column. " + exception.Message, "Column Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //----------------FOOTER BUTTONS----------------
        private void addFootersButton_Click(object sender, EventArgs e)
        {
            using (AddFooterModal addFooterModal = new AddFooterModal(ref footerDataGridView))
            {
                addFooterModal.ShowDialog();
            }
        }

        private void removeFootersButton_Click(object sender, EventArgs e)
        {
            int footerNumber = 0;

            DataGridViewRow footerRow;

            if (footerDataGridView.Rows.Count > 0)
            {
                footerRow = headerDataGridView.CurrentRow;

                footerNumber = Convert.ToInt32(footerRow.Cells["footerNumber"].Value);

                try
                {
                    FooterDAO footerDAO = new FooterDAO(ConfigurationDatabase);
                    footerDAO.Delete(FileTypeID, footerNumber);

                    Footers = footerDAO.GetFootersByFileTypeID(FileTypeID);

                    if (Footers != null)
                    {
                        footerDataGridView.Rows.Remove(footerRow);

                        foreach (DataGridViewRow row in footerDataGridView.Rows)
                        {
                            row.Cells["footerNumber"].Value = row.Cells["footerNumber"].RowIndex;
                        }

                        footerDataGridView.Refresh();
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
