using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ethosIQ_Database;
using ethosIQ_File_Reader_Shared;
using ethosIQ_File_Reader_Shared.DAO;
using ethosIQ_File_Reader_Shared.FileConfig;

namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    public partial class CreateFileTypeModal : Form
    {
        public int FileTypeID;
        public FileType FileType;
        public Database ConfigurationDatabase;
        private List<Header> Headers;
        private List<Column> Columns;
        private List<Footer> Footers;
        private DataGridView DataGridView;

        public CreateFileTypeModal(ref DataGridView DataGridView, Database ConfigurationDatabase)
        {
            InitializeComponent();
            this.ConfigurationDatabase = ConfigurationDatabase;
            this.DataGridView = DataGridView;
        }

        private void createFileTypeButton_Click(object sender, EventArgs e)
        {
            FileType = new FileType();

            if (nameTextBox.Text != "")
            {
                FileType.Name = nameTextBox.Text;
            }
            else
            {
                MessageBox.Show("File Type name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (delimiterTextBox.Text != "")
            {
                try
                {
                    FileType.Delimiter = delimiterTextBox.Text;
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Delimiter must be a single character. " + exception.Message, "Delimiter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Delimiter cannot be an empty string.", "Enter Delimiter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(storedProcedureTextBox.Text != "")
            {
                FileType.DatabaseStoredProcedureName = storedProcedureTextBox.Text;
            }
            else
            {
                MessageBox.Show("Procedure cannot be an empty string.", "Enter Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ConfigurationDatabase != null)
            {
                try
                {
                    FileTypeDAO fileTypeDAO = new FileTypeDAO(ConfigurationDatabase);

                    int result = fileTypeDAO.CreateFileType(FileType);

                    if (result == 0)
                    {
                        MessageBox.Show("Failed to create the file type. Make sure to use a unique name and check the configuration database connection.", "Failed To Create File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FileType.FileTypeID = result;
                        fileTypeIDTextBox.Text = result.ToString();

                        headerGroupBox.Enabled = true;
                        footerGroupBox.Enabled = true;
                        columnGroupBox.Enabled = true;
                        settingsGroupBox.Enabled = true;

                        FileTypeID = result;

                        DataGridView.Invoke(new Action(() => DataGridView.Rows.Add(FileType.FileTypeID, FileType.Name, FileType.Delimiter, FileType.DatabaseStoredProcedureName)));
                    }
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Failed to create new file type. " + exception.Message, "Create New File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FileType = null;
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
                    headerDAO.Insert(new Header(FileTypeID, row.Index, row.Cells[1].Value.ToString()));
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
            catch (Exception exception)
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

                        foreach(DataGridViewRow row in headerDataGridView.Rows)
                        {
                            row.Cells["headerNumber"].Value = row.Cells["headerNumber"].RowIndex;
                        }

                        headerDataGridView.Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to remove File Source. " + exception.Message, "File Source Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void fileTypeDelimiterLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
