using ethosIQ_Database;
using ethosIQ_File_Reader_Shared;
using ethosIQ_File_Reader_Shared.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ethosIQ_File_Reader_Tool
{
    public class AddFileSourceModal : Form
    {
        private Label nameLabel;
        private Label directoryLabel;
        private TextBox nameTextBox;
        private TextBox directoryTextBox;
        private Button addButton;
        private FolderBrowserDialog chooseDirectoryDialog;
        private Button chooseDirectoryButton;
        private Database ConfigurationDatabase;
        private Label fileTypeLabel;
        private MaskedTextBox fileTypeTextBox;
        private DataGridView Table;


        public AddFileSourceModal(ref DataGridView Table, Database ConfigurationDatabase)
        {
            InitializeComponent();
            this.Table = Table;
            this.ConfigurationDatabase = ConfigurationDatabase;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFileSourceModal));
            this.nameLabel = new System.Windows.Forms.Label();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.chooseDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.chooseDirectoryButton = new System.Windows.Forms.Button();
            this.fileTypeLabel = new System.Windows.Forms.Label();
            this.fileTypeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nameLabel.Location = new System.Drawing.Point(29, 36);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(51, 16);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name: ";
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.directoryLabel.Location = new System.Drawing.Point(12, 70);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(68, 16);
            this.directoryLabel.TabIndex = 1;
            this.directoryLabel.Text = "Directory: ";
            this.directoryLabel.Click += new System.EventHandler(this.directoryLabel_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(86, 33);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(139, 22);
            this.nameTextBox.TabIndex = 3;
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(86, 67);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(233, 22);
            this.directoryTextBox.TabIndex = 4;
            this.directoryTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(281, 128);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // chooseDirectoryButton
            // 
            this.chooseDirectoryButton.Location = new System.Drawing.Point(325, 67);
            this.chooseDirectoryButton.Name = "chooseDirectoryButton";
            this.chooseDirectoryButton.Size = new System.Drawing.Size(31, 23);
            this.chooseDirectoryButton.TabIndex = 11;
            this.chooseDirectoryButton.Text = "...";
            this.chooseDirectoryButton.UseVisualStyleBackColor = true;
            this.chooseDirectoryButton.Click += new System.EventHandler(this.chooseDirectoryButton_Click);
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoSize = true;
            this.fileTypeLabel.Location = new System.Drawing.Point(12, 104);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(68, 16);
            this.fileTypeLabel.TabIndex = 12;
            this.fileTypeLabel.Text = "File Type:";
            this.fileTypeLabel.Click += new System.EventHandler(this.fileTypeLabel_Click);
            // 
            // fileTypeTextBox
            // 
            this.fileTypeTextBox.Location = new System.Drawing.Point(87, 104);
            this.fileTypeTextBox.Mask = "00000";
            this.fileTypeTextBox.Name = "fileTypeTextBox";
            this.fileTypeTextBox.Size = new System.Drawing.Size(43, 22);
            this.fileTypeTextBox.TabIndex = 13;
            this.fileTypeTextBox.ValidatingType = typeof(int);
            // 
            // AddFileSourceModal
            // 
            this.ClientSize = new System.Drawing.Size(373, 163);
            this.Controls.Add(this.fileTypeTextBox);
            this.Controls.Add(this.fileTypeLabel);
            this.Controls.Add(this.chooseDirectoryButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFileSourceModal";
            this.Text = "Add File Source";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void directoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileSource source = new FileSource();

                if (nameTextBox.Text != "")
                {
                    source.Name = nameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (directoryTextBox.Text != "")
                {
                    source.Directory = directoryTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Directory cannot be an empty string.", "Select Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(fileTypeTextBox.Text != "")
                {
                    source.FileTypeID = Convert.ToInt32(fileTypeTextBox.Text);
                }
                else
                {
                    MessageBox.Show("File Type cannot be an empty string.", "Select Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileSourceDAO fileSourceDAO = new FileSourceDAO(ConfigurationDatabase);
                int result = fileSourceDAO.Insert(source);

                if(result == 0)
                {
                    source.FileTypeID = 0;
                }

                Table.Invoke(new Action(() => Table.Rows.Add(source.FileTypeID, source.Name, source.Directory)));
                Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed To Add Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult chooseDirectoryResult = chooseDirectoryDialog.ShowDialog();

            if (chooseDirectoryResult == DialogResult.OK && !string.IsNullOrWhiteSpace(chooseDirectoryDialog.SelectedPath))
            {
                directoryTextBox.Text = chooseDirectoryDialog.SelectedPath;
            }
        }

        private void fileTypeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
