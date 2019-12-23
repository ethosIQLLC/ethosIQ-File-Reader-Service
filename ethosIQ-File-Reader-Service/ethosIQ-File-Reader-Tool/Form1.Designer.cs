namespace ethosIQ_File_Reader_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.collectionDatabaseGroupBox = new System.Windows.Forms.GroupBox();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.checkDatabaseConnectionButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.dataSourceTextBox = new System.Windows.Forms.TextBox();
            this.databaseTypeTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.dataSourceLabel = new System.Windows.Forms.Label();
            this.databaseTypeLabel = new System.Windows.Forms.Label();
            this.remoteFTPConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.removeFileSourceButton = new System.Windows.Forms.Button();
            this.addFileSourceButton = new System.Windows.Forms.Button();
            this.fileSourceGridView = new System.Windows.Forms.DataGridView();
            this.fileSourceFileTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadConfigurationWorker = new System.ComponentModel.BackgroundWorker();
            this.checkCollectionDatabaseConnectionWorker = new System.ComponentModel.BackgroundWorker();
            this.fileTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.editFileTypeButton = new System.Windows.Forms.Button();
            this.removeFileTypeButton = new System.Windows.Forms.Button();
            this.addFileTypeButton = new System.Windows.Forms.Button();
            this.fileTypeGridView = new System.Windows.Forms.DataGridView();
            this.fileTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileTypeDelimiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseStoredProcedureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.collectionDatabaseGroupBox.SuspendLayout();
            this.remoteFTPConfigurationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSourceGridView)).BeginInit();
            this.fileTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileTypeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(417, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // collectionDatabaseGroupBox
            // 
            this.collectionDatabaseGroupBox.Controls.Add(this.connectedLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.checkDatabaseConnectionButton);
            this.collectionDatabaseGroupBox.Controls.Add(this.statusLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.passwordTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.usernameTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.passwordLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.usernameLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.portTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.hostTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.dataSourceTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.databaseTypeTextBox);
            this.collectionDatabaseGroupBox.Controls.Add(this.portLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.hostLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.dataSourceLabel);
            this.collectionDatabaseGroupBox.Controls.Add(this.databaseTypeLabel);
            this.collectionDatabaseGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionDatabaseGroupBox.Location = new System.Drawing.Point(13, 93);
            this.collectionDatabaseGroupBox.Name = "collectionDatabaseGroupBox";
            this.collectionDatabaseGroupBox.Size = new System.Drawing.Size(499, 140);
            this.collectionDatabaseGroupBox.TabIndex = 3;
            this.collectionDatabaseGroupBox.TabStop = false;
            this.collectionDatabaseGroupBox.Text = "Collection Database";
            // 
            // connectedLabel
            // 
            this.connectedLabel.AutoSize = true;
            this.connectedLabel.Location = new System.Drawing.Point(344, 80);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(91, 16);
            this.connectedLabel.TabIndex = 14;
            this.connectedLabel.Text = "Disconnected";
            // 
            // checkDatabaseConnectionButton
            // 
            this.checkDatabaseConnectionButton.Location = new System.Drawing.Point(344, 108);
            this.checkDatabaseConnectionButton.Name = "checkDatabaseConnectionButton";
            this.checkDatabaseConnectionButton.Size = new System.Drawing.Size(132, 23);
            this.checkDatabaseConnectionButton.TabIndex = 13;
            this.checkDatabaseConnectionButton.Text = "Check Connection";
            this.checkDatabaseConnectionButton.UseVisualStyleBackColor = true;
            this.checkDatabaseConnectionButton.Click += new System.EventHandler(this.checkDatabaseConnectionButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(287, 80);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 16);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status: ";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(344, 48);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(149, 22);
            this.passwordTextBox.TabIndex = 11;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(344, 19);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(149, 22);
            this.usernameTextBox.TabIndex = 10;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(264, 51);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(74, 16);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password: ";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(261, 23);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 16);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.Text = "Username: ";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(125, 108);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(121, 22);
            this.portTextBox.TabIndex = 7;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(125, 77);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(121, 22);
            this.hostTextBox.TabIndex = 6;
            // 
            // dataSourceTextBox
            // 
            this.dataSourceTextBox.Location = new System.Drawing.Point(125, 48);
            this.dataSourceTextBox.Name = "dataSourceTextBox";
            this.dataSourceTextBox.Size = new System.Drawing.Size(121, 22);
            this.dataSourceTextBox.TabIndex = 5;
            // 
            // databaseTypeTextBox
            // 
            this.databaseTypeTextBox.Location = new System.Drawing.Point(125, 19);
            this.databaseTypeTextBox.Name = "databaseTypeTextBox";
            this.databaseTypeTextBox.Size = new System.Drawing.Size(121, 22);
            this.databaseTypeTextBox.TabIndex = 4;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(81, 111);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 16);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port: ";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(77, 80);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(42, 16);
            this.hostLabel.TabIndex = 2;
            this.hostLabel.Text = "Host: ";
            // 
            // dataSourceLabel
            // 
            this.dataSourceLabel.AutoSize = true;
            this.dataSourceLabel.Location = new System.Drawing.Point(30, 51);
            this.dataSourceLabel.Name = "dataSourceLabel";
            this.dataSourceLabel.Size = new System.Drawing.Size(89, 16);
            this.dataSourceLabel.TabIndex = 1;
            this.dataSourceLabel.Text = "Data Source: ";
            // 
            // databaseTypeLabel
            // 
            this.databaseTypeLabel.AutoSize = true;
            this.databaseTypeLabel.Location = new System.Drawing.Point(10, 22);
            this.databaseTypeLabel.Name = "databaseTypeLabel";
            this.databaseTypeLabel.Size = new System.Drawing.Size(109, 16);
            this.databaseTypeLabel.TabIndex = 0;
            this.databaseTypeLabel.Text = "Database Type: ";
            // 
            // remoteFTPConfigurationGroupBox
            // 
            this.remoteFTPConfigurationGroupBox.Controls.Add(this.removeFileSourceButton);
            this.remoteFTPConfigurationGroupBox.Controls.Add(this.addFileSourceButton);
            this.remoteFTPConfigurationGroupBox.Controls.Add(this.fileSourceGridView);
            this.remoteFTPConfigurationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.remoteFTPConfigurationGroupBox.Location = new System.Drawing.Point(12, 234);
            this.remoteFTPConfigurationGroupBox.Name = "remoteFTPConfigurationGroupBox";
            this.remoteFTPConfigurationGroupBox.Size = new System.Drawing.Size(500, 178);
            this.remoteFTPConfigurationGroupBox.TabIndex = 4;
            this.remoteFTPConfigurationGroupBox.TabStop = false;
            this.remoteFTPConfigurationGroupBox.Text = "File Source Configuration";
            // 
            // removeFileSourceButton
            // 
            this.removeFileSourceButton.Location = new System.Drawing.Point(145, 151);
            this.removeFileSourceButton.Name = "removeFileSourceButton";
            this.removeFileSourceButton.Size = new System.Drawing.Size(132, 23);
            this.removeFileSourceButton.TabIndex = 2;
            this.removeFileSourceButton.Text = "Remove";
            this.removeFileSourceButton.UseVisualStyleBackColor = true;
            this.removeFileSourceButton.Click += new System.EventHandler(this.removeFileSourceButton_Click);
            // 
            // addFileSourceButton
            // 
            this.addFileSourceButton.Location = new System.Drawing.Point(7, 151);
            this.addFileSourceButton.Name = "addFileSourceButton";
            this.addFileSourceButton.Size = new System.Drawing.Size(132, 23);
            this.addFileSourceButton.TabIndex = 1;
            this.addFileSourceButton.Text = "Add";
            this.addFileSourceButton.UseVisualStyleBackColor = true;
            this.addFileSourceButton.Click += new System.EventHandler(this.addFileSourceButton_Click);
            // 
            // fileSourceGridView
            // 
            this.fileSourceGridView.AllowUserToAddRows = false;
            this.fileSourceGridView.AllowUserToDeleteRows = false;
            this.fileSourceGridView.AllowUserToOrderColumns = true;
            this.fileSourceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileSourceFileTypeID,
            this.columnName,
            this.Directory});
            this.fileSourceGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fileSourceGridView.Location = new System.Drawing.Point(7, 22);
            this.fileSourceGridView.MultiSelect = false;
            this.fileSourceGridView.Name = "fileSourceGridView";
            this.fileSourceGridView.ReadOnly = true;
            this.fileSourceGridView.RowHeadersVisible = false;
            this.fileSourceGridView.Size = new System.Drawing.Size(487, 123);
            this.fileSourceGridView.TabIndex = 0;
            // 
            // fileSourceFileTypeID
            // 
            this.fileSourceFileTypeID.HeaderText = "File Type ID";
            this.fileSourceFileTypeID.Name = "fileSourceFileTypeID";
            this.fileSourceFileTypeID.ReadOnly = true;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // Directory
            // 
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // loadConfigurationWorker
            // 
            this.loadConfigurationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadConfigurationWorker_DoWork);
            // 
            // checkCollectionDatabaseConnectionWorker
            // 
            this.checkCollectionDatabaseConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkCollectionDatabaseConnectionWorker_DoWork);
            // 
            // fileTypeGroupBox
            // 
            this.fileTypeGroupBox.Controls.Add(this.editFileTypeButton);
            this.fileTypeGroupBox.Controls.Add(this.removeFileTypeButton);
            this.fileTypeGroupBox.Controls.Add(this.addFileTypeButton);
            this.fileTypeGroupBox.Controls.Add(this.fileTypeGridView);
            this.fileTypeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.fileTypeGroupBox.Location = new System.Drawing.Point(13, 413);
            this.fileTypeGroupBox.Name = "fileTypeGroupBox";
            this.fileTypeGroupBox.Size = new System.Drawing.Size(500, 178);
            this.fileTypeGroupBox.TabIndex = 5;
            this.fileTypeGroupBox.TabStop = false;
            this.fileTypeGroupBox.Text = "File Type Configuration";
            // 
            // editFileTypeButton
            // 
            this.editFileTypeButton.Location = new System.Drawing.Point(144, 150);
            this.editFileTypeButton.Name = "editFileTypeButton";
            this.editFileTypeButton.Size = new System.Drawing.Size(132, 23);
            this.editFileTypeButton.TabIndex = 3;
            this.editFileTypeButton.Text = "Edit";
            this.editFileTypeButton.UseVisualStyleBackColor = true;
            this.editFileTypeButton.Click += new System.EventHandler(this.editFileTypeButton_Click);
            // 
            // removeFileTypeButton
            // 
            this.removeFileTypeButton.Location = new System.Drawing.Point(282, 149);
            this.removeFileTypeButton.Name = "removeFileTypeButton";
            this.removeFileTypeButton.Size = new System.Drawing.Size(132, 23);
            this.removeFileTypeButton.TabIndex = 2;
            this.removeFileTypeButton.Text = "Remove";
            this.removeFileTypeButton.UseVisualStyleBackColor = true;
            this.removeFileTypeButton.Click += new System.EventHandler(this.removeFileTypeButton_Click);
            // 
            // addFileTypeButton
            // 
            this.addFileTypeButton.Location = new System.Drawing.Point(6, 150);
            this.addFileTypeButton.Name = "addFileTypeButton";
            this.addFileTypeButton.Size = new System.Drawing.Size(132, 23);
            this.addFileTypeButton.TabIndex = 1;
            this.addFileTypeButton.Text = "Add";
            this.addFileTypeButton.UseVisualStyleBackColor = true;
            this.addFileTypeButton.Click += new System.EventHandler(this.addFileTypeButton_Click);
            // 
            // fileTypeGridView
            // 
            this.fileTypeGridView.AllowUserToAddRows = false;
            this.fileTypeGridView.AllowUserToDeleteRows = false;
            this.fileTypeGridView.AllowUserToOrderColumns = true;
            this.fileTypeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileTypeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileTypeID,
            this.fileTypeName,
            this.fileTypeDelimiter,
            this.databaseStoredProcedureName});
            this.fileTypeGridView.Location = new System.Drawing.Point(6, 21);
            this.fileTypeGridView.MultiSelect = false;
            this.fileTypeGridView.Name = "fileTypeGridView";
            this.fileTypeGridView.ReadOnly = true;
            this.fileTypeGridView.RowHeadersVisible = false;
            this.fileTypeGridView.Size = new System.Drawing.Size(487, 123);
            this.fileTypeGridView.TabIndex = 0;
            // 
            // fileTypeID
            // 
            this.fileTypeID.HeaderText = "#";
            this.fileTypeID.Name = "fileTypeID";
            this.fileTypeID.ReadOnly = true;
            this.fileTypeID.Width = 30;
            // 
            // fileTypeName
            // 
            this.fileTypeName.HeaderText = "Name";
            this.fileTypeName.Name = "fileTypeName";
            this.fileTypeName.ReadOnly = true;
            this.fileTypeName.Width = 200;
            // 
            // fileTypeDelimiter
            // 
            this.fileTypeDelimiter.HeaderText = "Delimiter";
            this.fileTypeDelimiter.Name = "fileTypeDelimiter";
            this.fileTypeDelimiter.ReadOnly = true;
            // 
            // databaseStoredProcedureName
            // 
            this.databaseStoredProcedureName.HeaderText = "Procedure Name";
            this.databaseStoredProcedureName.Name = "databaseStoredProcedureName";
            this.databaseStoredProcedureName.ReadOnly = true;
            this.databaseStoredProcedureName.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 597);
            this.Controls.Add(this.fileTypeGroupBox);
            this.Controls.Add(this.remoteFTPConfigurationGroupBox);
            this.Controls.Add(this.collectionDatabaseGroupBox);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ethosIQ File Reader Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.collectionDatabaseGroupBox.ResumeLayout(false);
            this.collectionDatabaseGroupBox.PerformLayout();
            this.remoteFTPConfigurationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSourceGridView)).EndInit();
            this.fileTypeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileTypeGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox collectionDatabaseGroupBox;
        private System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Button checkDatabaseConnectionButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox dataSourceTextBox;
        private System.Windows.Forms.TextBox databaseTypeTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label dataSourceLabel;
        private System.Windows.Forms.Label databaseTypeLabel;
        private System.Windows.Forms.GroupBox remoteFTPConfigurationGroupBox;
        private System.Windows.Forms.Button removeFileSourceButton;
        private System.Windows.Forms.Button addFileSourceButton;
        private System.Windows.Forms.DataGridView fileSourceGridView;
        private System.ComponentModel.BackgroundWorker loadConfigurationWorker;
        private System.ComponentModel.BackgroundWorker checkCollectionDatabaseConnectionWorker;
        private System.Windows.Forms.GroupBox fileTypeGroupBox;
        private System.Windows.Forms.Button removeFileTypeButton;
        private System.Windows.Forms.Button addFileTypeButton;
        private System.Windows.Forms.DataGridView fileTypeGridView;
        private System.Windows.Forms.Button editFileTypeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSourceFileTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileTypeDelimiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseStoredProcedureName;
    }
}

