namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    partial class EditFileTypeModal
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
            this.headerGroupBox = new System.Windows.Forms.GroupBox();
            this.removeHeaderButton = new System.Windows.Forms.Button();
            this.headerDataGridView = new System.Windows.Forms.DataGridView();
            this.headerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addHeaderButton = new System.Windows.Forms.Button();
            this.columnGroupBox = new System.Windows.Forms.GroupBox();
            this.columnDataGridView = new System.Windows.Forms.DataGridView();
            this.columnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ignoreColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notInFileColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.removeColumnButton = new System.Windows.Forms.Button();
            this.footerGroupBox = new System.Windows.Forms.GroupBox();
            this.footerDataGridView = new System.Windows.Forms.DataGridView();
            this.footerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFootersButton = new System.Windows.Forms.Button();
            this.removeFootersButton = new System.Windows.Forms.Button();
            this.saveFileTypeButton = new System.Windows.Forms.Button();
            this.fileTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.storedProcedureTextBox = new System.Windows.Forms.TextBox();
            this.storedProcedureLabel = new System.Windows.Forms.Label();
            this.fileTypeIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.delimiterTextBox = new System.Windows.Forms.TextBox();
            this.fileTypeDelimiterLabel = new System.Windows.Forms.Label();
            this.fileTypeIDLable = new System.Windows.Forms.Label();
            this.fileTypeNameLabel = new System.Windows.Forms.Label();
            this.loadEditFileTypeWorker = new System.ComponentModel.BackgroundWorker();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.dateTimeColumnTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeColumnLabel = new System.Windows.Forms.Label();
            this.linkDateTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.dateTimeFormatFileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeFormatFileExtensionLabel = new System.Windows.Forms.Label();
            this.textToIgnoreFileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.textToIgnoreFileExtensionLabel = new System.Windows.Forms.Label();
            this.dateTimeFormatFileNameTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeFormatFileNameLabel = new System.Windows.Forms.Label();
            this.useFileExtensionCheckBox = new System.Windows.Forms.CheckBox();
            this.textToIgnoreFileNameLabel = new System.Windows.Forms.Label();
            this.textToIgnoreFileNameTextBox = new System.Windows.Forms.TextBox();
            this.useFileNameCheckBox = new System.Windows.Forms.CheckBox();
            this.truncateTableCheckBox = new System.Windows.Forms.CheckBox();
            this.headerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerDataGridView)).BeginInit();
            this.columnGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnDataGridView)).BeginInit();
            this.footerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerDataGridView)).BeginInit();
            this.fileTypeGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupBox
            // 
            this.headerGroupBox.Controls.Add(this.removeHeaderButton);
            this.headerGroupBox.Controls.Add(this.headerDataGridView);
            this.headerGroupBox.Controls.Add(this.addHeaderButton);
            this.headerGroupBox.Enabled = false;
            this.headerGroupBox.Location = new System.Drawing.Point(13, 197);
            this.headerGroupBox.Name = "headerGroupBox";
            this.headerGroupBox.Size = new System.Drawing.Size(362, 157);
            this.headerGroupBox.TabIndex = 0;
            this.headerGroupBox.TabStop = false;
            this.headerGroupBox.Text = "Headers";
            // 
            // removeHeaderButton
            // 
            this.removeHeaderButton.Location = new System.Drawing.Point(276, 124);
            this.removeHeaderButton.Name = "removeHeaderButton";
            this.removeHeaderButton.Size = new System.Drawing.Size(75, 23);
            this.removeHeaderButton.TabIndex = 3;
            this.removeHeaderButton.Text = "Remove";
            this.removeHeaderButton.UseVisualStyleBackColor = true;
            this.removeHeaderButton.Click += new System.EventHandler(this.removeHeaderButton_Click);
            // 
            // headerDataGridView
            // 
            this.headerDataGridView.AllowUserToAddRows = false;
            this.headerDataGridView.AllowUserToDeleteRows = false;
            this.headerDataGridView.AllowUserToOrderColumns = true;
            this.headerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headerNumber,
            this.headerName});
            this.headerDataGridView.Location = new System.Drawing.Point(9, 19);
            this.headerDataGridView.MultiSelect = false;
            this.headerDataGridView.Name = "headerDataGridView";
            this.headerDataGridView.ReadOnly = true;
            this.headerDataGridView.RowHeadersVisible = false;
            this.headerDataGridView.Size = new System.Drawing.Size(263, 128);
            this.headerDataGridView.TabIndex = 4;
            // 
            // headerNumber
            // 
            this.headerNumber.Frozen = true;
            this.headerNumber.HeaderText = "#";
            this.headerNumber.Name = "headerNumber";
            this.headerNumber.ReadOnly = true;
            this.headerNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.headerNumber.Width = 25;
            // 
            // headerName
            // 
            this.headerName.HeaderText = "Header Name";
            this.headerName.Name = "headerName";
            this.headerName.ReadOnly = true;
            this.headerName.Width = 235;
            // 
            // addHeaderButton
            // 
            this.addHeaderButton.Location = new System.Drawing.Point(276, 95);
            this.addHeaderButton.Name = "addHeaderButton";
            this.addHeaderButton.Size = new System.Drawing.Size(75, 23);
            this.addHeaderButton.TabIndex = 1;
            this.addHeaderButton.Text = "Add";
            this.addHeaderButton.UseVisualStyleBackColor = true;
            this.addHeaderButton.Click += new System.EventHandler(this.addHeaderButton_Click);
            // 
            // columnGroupBox
            // 
            this.columnGroupBox.Controls.Add(this.columnDataGridView);
            this.columnGroupBox.Controls.Add(this.addColumnButton);
            this.columnGroupBox.Controls.Add(this.removeColumnButton);
            this.columnGroupBox.Enabled = false;
            this.columnGroupBox.Location = new System.Drawing.Point(392, 197);
            this.columnGroupBox.Name = "columnGroupBox";
            this.columnGroupBox.Size = new System.Drawing.Size(362, 320);
            this.columnGroupBox.TabIndex = 1;
            this.columnGroupBox.TabStop = false;
            this.columnGroupBox.Text = "Columns";
            // 
            // columnDataGridView
            // 
            this.columnDataGridView.AllowUserToAddRows = false;
            this.columnDataGridView.AllowUserToDeleteRows = false;
            this.columnDataGridView.AllowUserToOrderColumns = true;
            this.columnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.columnDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNumber,
            this.columnName,
            this.databaseColumnName,
            this.ignoreColumn,
            this.notInFileColumn});
            this.columnDataGridView.Location = new System.Drawing.Point(6, 19);
            this.columnDataGridView.Name = "columnDataGridView";
            this.columnDataGridView.RowHeadersVisible = false;
            this.columnDataGridView.Size = new System.Drawing.Size(264, 290);
            this.columnDataGridView.TabIndex = 5;
            // 
            // columnNumber
            // 
            this.columnNumber.HeaderText = "#";
            this.columnNumber.Name = "columnNumber";
            this.columnNumber.Width = 25;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Column Name";
            this.columnName.Name = "columnName";
            // 
            // databaseColumnName
            // 
            this.databaseColumnName.HeaderText = "Database Column Name";
            this.databaseColumnName.Name = "databaseColumnName";
            this.databaseColumnName.Width = 145;
            // 
            // ignoreColumn
            // 
            this.ignoreColumn.HeaderText = "Ignore";
            this.ignoreColumn.Name = "ignoreColumn";
            // 
            // notInFileColumn
            // 
            this.notInFileColumn.HeaderText = "Not In File";
            this.notInFileColumn.Name = "notInFileColumn";
            this.notInFileColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.notInFileColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // addColumnButton
            // 
            this.addColumnButton.Location = new System.Drawing.Point(276, 257);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(75, 23);
            this.addColumnButton.TabIndex = 3;
            this.addColumnButton.Text = "Add";
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // removeColumnButton
            // 
            this.removeColumnButton.Location = new System.Drawing.Point(276, 287);
            this.removeColumnButton.Name = "removeColumnButton";
            this.removeColumnButton.Size = new System.Drawing.Size(75, 23);
            this.removeColumnButton.TabIndex = 1;
            this.removeColumnButton.Text = "Remove";
            this.removeColumnButton.UseVisualStyleBackColor = true;
            this.removeColumnButton.Click += new System.EventHandler(this.removeColumnButton_Click);
            // 
            // footerGroupBox
            // 
            this.footerGroupBox.Controls.Add(this.footerDataGridView);
            this.footerGroupBox.Controls.Add(this.addFootersButton);
            this.footerGroupBox.Controls.Add(this.removeFootersButton);
            this.footerGroupBox.Enabled = false;
            this.footerGroupBox.Location = new System.Drawing.Point(13, 360);
            this.footerGroupBox.Name = "footerGroupBox";
            this.footerGroupBox.Size = new System.Drawing.Size(362, 157);
            this.footerGroupBox.TabIndex = 2;
            this.footerGroupBox.TabStop = false;
            this.footerGroupBox.Text = "Footers";
            // 
            // footerDataGridView
            // 
            this.footerDataGridView.AllowUserToAddRows = false;
            this.footerDataGridView.AllowUserToDeleteRows = false;
            this.footerDataGridView.AllowUserToOrderColumns = true;
            this.footerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.footerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.footerNumber,
            this.footerName});
            this.footerDataGridView.Location = new System.Drawing.Point(9, 18);
            this.footerDataGridView.Name = "footerDataGridView";
            this.footerDataGridView.ReadOnly = true;
            this.footerDataGridView.RowHeadersVisible = false;
            this.footerDataGridView.Size = new System.Drawing.Size(264, 128);
            this.footerDataGridView.TabIndex = 6;
            // 
            // footerNumber
            // 
            this.footerNumber.HeaderText = "#";
            this.footerNumber.Name = "footerNumber";
            this.footerNumber.ReadOnly = true;
            this.footerNumber.Width = 25;
            // 
            // footerName
            // 
            this.footerName.HeaderText = "Footer Name";
            this.footerName.Name = "footerName";
            this.footerName.ReadOnly = true;
            this.footerName.Width = 235;
            // 
            // addFootersButton
            // 
            this.addFootersButton.Location = new System.Drawing.Point(277, 94);
            this.addFootersButton.Name = "addFootersButton";
            this.addFootersButton.Size = new System.Drawing.Size(75, 23);
            this.addFootersButton.TabIndex = 3;
            this.addFootersButton.Text = "Add";
            this.addFootersButton.UseVisualStyleBackColor = true;
            // 
            // removeFootersButton
            // 
            this.removeFootersButton.Location = new System.Drawing.Point(277, 123);
            this.removeFootersButton.Name = "removeFootersButton";
            this.removeFootersButton.Size = new System.Drawing.Size(75, 23);
            this.removeFootersButton.TabIndex = 1;
            this.removeFootersButton.Text = "Remove";
            this.removeFootersButton.UseVisualStyleBackColor = true;
            // 
            // saveFileTypeButton
            // 
            this.saveFileTypeButton.Location = new System.Drawing.Point(668, 523);
            this.saveFileTypeButton.Name = "saveFileTypeButton";
            this.saveFileTypeButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileTypeButton.TabIndex = 3;
            this.saveFileTypeButton.Text = "Save";
            this.saveFileTypeButton.UseVisualStyleBackColor = true;
            this.saveFileTypeButton.Click += new System.EventHandler(this.saveFileTypeButton_Click);
            // 
            // fileTypeGroupBox
            // 
            this.fileTypeGroupBox.Controls.Add(this.storedProcedureTextBox);
            this.fileTypeGroupBox.Controls.Add(this.storedProcedureLabel);
            this.fileTypeGroupBox.Controls.Add(this.fileTypeIDTextBox);
            this.fileTypeGroupBox.Controls.Add(this.nameTextBox);
            this.fileTypeGroupBox.Controls.Add(this.delimiterTextBox);
            this.fileTypeGroupBox.Controls.Add(this.fileTypeDelimiterLabel);
            this.fileTypeGroupBox.Controls.Add(this.fileTypeIDLable);
            this.fileTypeGroupBox.Controls.Add(this.fileTypeNameLabel);
            this.fileTypeGroupBox.Location = new System.Drawing.Point(13, 12);
            this.fileTypeGroupBox.Name = "fileTypeGroupBox";
            this.fileTypeGroupBox.Size = new System.Drawing.Size(282, 149);
            this.fileTypeGroupBox.TabIndex = 5;
            this.fileTypeGroupBox.TabStop = false;
            this.fileTypeGroupBox.Text = "File Type";
            // 
            // storedProcedureTextBox
            // 
            this.storedProcedureTextBox.Enabled = false;
            this.storedProcedureTextBox.Location = new System.Drawing.Point(79, 92);
            this.storedProcedureTextBox.Name = "storedProcedureTextBox";
            this.storedProcedureTextBox.Size = new System.Drawing.Size(193, 20);
            this.storedProcedureTextBox.TabIndex = 10;
            // 
            // storedProcedureLabel
            // 
            this.storedProcedureLabel.AutoSize = true;
            this.storedProcedureLabel.Location = new System.Drawing.Point(5, 95);
            this.storedProcedureLabel.Name = "storedProcedureLabel";
            this.storedProcedureLabel.Size = new System.Drawing.Size(68, 13);
            this.storedProcedureLabel.TabIndex = 9;
            this.storedProcedureLabel.Text = "Table Name:";
            // 
            // fileTypeIDTextBox
            // 
            this.fileTypeIDTextBox.Enabled = false;
            this.fileTypeIDTextBox.Location = new System.Drawing.Point(79, 20);
            this.fileTypeIDTextBox.Name = "fileTypeIDTextBox";
            this.fileTypeIDTextBox.Size = new System.Drawing.Size(31, 20);
            this.fileTypeIDTextBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(79, 46);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // delimiterTextBox
            // 
            this.delimiterTextBox.Enabled = false;
            this.delimiterTextBox.Location = new System.Drawing.Point(79, 69);
            this.delimiterTextBox.Name = "delimiterTextBox";
            this.delimiterTextBox.Size = new System.Drawing.Size(100, 20);
            this.delimiterTextBox.TabIndex = 3;
            // 
            // fileTypeDelimiterLabel
            // 
            this.fileTypeDelimiterLabel.AutoSize = true;
            this.fileTypeDelimiterLabel.Location = new System.Drawing.Point(23, 72);
            this.fileTypeDelimiterLabel.Name = "fileTypeDelimiterLabel";
            this.fileTypeDelimiterLabel.Size = new System.Drawing.Size(50, 13);
            this.fileTypeDelimiterLabel.TabIndex = 2;
            this.fileTypeDelimiterLabel.Text = "Delimiter:";
            // 
            // fileTypeIDLable
            // 
            this.fileTypeIDLable.AutoSize = true;
            this.fileTypeIDLable.Location = new System.Drawing.Point(6, 23);
            this.fileTypeIDLable.Name = "fileTypeIDLable";
            this.fileTypeIDLable.Size = new System.Drawing.Size(67, 13);
            this.fileTypeIDLable.TabIndex = 1;
            this.fileTypeIDLable.Text = "File Type ID:";
            // 
            // fileTypeNameLabel
            // 
            this.fileTypeNameLabel.AutoSize = true;
            this.fileTypeNameLabel.Location = new System.Drawing.Point(35, 49);
            this.fileTypeNameLabel.Name = "fileTypeNameLabel";
            this.fileTypeNameLabel.Size = new System.Drawing.Size(38, 13);
            this.fileTypeNameLabel.TabIndex = 0;
            this.fileTypeNameLabel.Text = "Name:";
            // 
            // loadEditFileTypeWorker
            // 
            this.loadEditFileTypeWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadEditFileTypeWorker_DoWork);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.truncateTableCheckBox);
            this.settingsGroupBox.Controls.Add(this.dateTimeColumnTextBox);
            this.settingsGroupBox.Controls.Add(this.dateTimeColumnLabel);
            this.settingsGroupBox.Controls.Add(this.linkDateTimeCheckBox);
            this.settingsGroupBox.Controls.Add(this.dateTimeFormatFileExtensionTextBox);
            this.settingsGroupBox.Controls.Add(this.dateTimeFormatFileExtensionLabel);
            this.settingsGroupBox.Controls.Add(this.textToIgnoreFileExtensionTextBox);
            this.settingsGroupBox.Controls.Add(this.textToIgnoreFileExtensionLabel);
            this.settingsGroupBox.Controls.Add(this.dateTimeFormatFileNameTextBox);
            this.settingsGroupBox.Controls.Add(this.dateTimeFormatFileNameLabel);
            this.settingsGroupBox.Controls.Add(this.useFileExtensionCheckBox);
            this.settingsGroupBox.Controls.Add(this.textToIgnoreFileNameLabel);
            this.settingsGroupBox.Controls.Add(this.textToIgnoreFileNameTextBox);
            this.settingsGroupBox.Controls.Add(this.useFileNameCheckBox);
            this.settingsGroupBox.Enabled = false;
            this.settingsGroupBox.Location = new System.Drawing.Point(311, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(443, 179);
            this.settingsGroupBox.TabIndex = 7;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // dateTimeColumnTextBox
            // 
            this.dateTimeColumnTextBox.Location = new System.Drawing.Point(203, 124);
            this.dateTimeColumnTextBox.Name = "dateTimeColumnTextBox";
            this.dateTimeColumnTextBox.Size = new System.Drawing.Size(229, 20);
            this.dateTimeColumnTextBox.TabIndex = 12;
            // 
            // dateTimeColumnLabel
            // 
            this.dateTimeColumnLabel.AutoSize = true;
            this.dateTimeColumnLabel.Location = new System.Drawing.Point(103, 127);
            this.dateTimeColumnLabel.Name = "dateTimeColumnLabel";
            this.dateTimeColumnLabel.Size = new System.Drawing.Size(94, 13);
            this.dateTimeColumnLabel.TabIndex = 11;
            this.dateTimeColumnLabel.Text = "DateTime Column:";
            // 
            // linkDateTimeCheckBox
            // 
            this.linkDateTimeCheckBox.AutoSize = true;
            this.linkDateTimeCheckBox.Location = new System.Drawing.Point(6, 126);
            this.linkDateTimeCheckBox.Name = "linkDateTimeCheckBox";
            this.linkDateTimeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.linkDateTimeCheckBox.TabIndex = 10;
            this.linkDateTimeCheckBox.Text = "Link DateTime";
            this.linkDateTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateTimeFormatFileExtensionTextBox
            // 
            this.dateTimeFormatFileExtensionTextBox.Location = new System.Drawing.Point(203, 99);
            this.dateTimeFormatFileExtensionTextBox.Name = "dateTimeFormatFileExtensionTextBox";
            this.dateTimeFormatFileExtensionTextBox.Size = new System.Drawing.Size(229, 20);
            this.dateTimeFormatFileExtensionTextBox.TabIndex = 9;
            // 
            // dateTimeFormatFileExtensionLabel
            // 
            this.dateTimeFormatFileExtensionLabel.AutoSize = true;
            this.dateTimeFormatFileExtensionLabel.Location = new System.Drawing.Point(106, 102);
            this.dateTimeFormatFileExtensionLabel.Name = "dateTimeFormatFileExtensionLabel";
            this.dateTimeFormatFileExtensionLabel.Size = new System.Drawing.Size(91, 13);
            this.dateTimeFormatFileExtensionLabel.TabIndex = 8;
            this.dateTimeFormatFileExtensionLabel.Text = "DateTime Format:";
            // 
            // textToIgnoreFileExtensionTextBox
            // 
            this.textToIgnoreFileExtensionTextBox.Location = new System.Drawing.Point(203, 72);
            this.textToIgnoreFileExtensionTextBox.Name = "textToIgnoreFileExtensionTextBox";
            this.textToIgnoreFileExtensionTextBox.Size = new System.Drawing.Size(229, 20);
            this.textToIgnoreFileExtensionTextBox.TabIndex = 7;
            // 
            // textToIgnoreFileExtensionLabel
            // 
            this.textToIgnoreFileExtensionLabel.AutoSize = true;
            this.textToIgnoreFileExtensionLabel.Location = new System.Drawing.Point(117, 75);
            this.textToIgnoreFileExtensionLabel.Name = "textToIgnoreFileExtensionLabel";
            this.textToIgnoreFileExtensionLabel.Size = new System.Drawing.Size(80, 13);
            this.textToIgnoreFileExtensionLabel.TabIndex = 6;
            this.textToIgnoreFileExtensionLabel.Text = "Text To Ignore:";
            // 
            // dateTimeFormatFileNameTextBox
            // 
            this.dateTimeFormatFileNameTextBox.Location = new System.Drawing.Point(203, 43);
            this.dateTimeFormatFileNameTextBox.Name = "dateTimeFormatFileNameTextBox";
            this.dateTimeFormatFileNameTextBox.Size = new System.Drawing.Size(229, 20);
            this.dateTimeFormatFileNameTextBox.TabIndex = 5;
            // 
            // dateTimeFormatFileNameLabel
            // 
            this.dateTimeFormatFileNameLabel.AutoSize = true;
            this.dateTimeFormatFileNameLabel.Location = new System.Drawing.Point(106, 46);
            this.dateTimeFormatFileNameLabel.Name = "dateTimeFormatFileNameLabel";
            this.dateTimeFormatFileNameLabel.Size = new System.Drawing.Size(91, 13);
            this.dateTimeFormatFileNameLabel.TabIndex = 4;
            this.dateTimeFormatFileNameLabel.Text = "DateTime Format:";
            // 
            // useFileExtensionCheckBox
            // 
            this.useFileExtensionCheckBox.AutoSize = true;
            this.useFileExtensionCheckBox.Location = new System.Drawing.Point(6, 74);
            this.useFileExtensionCheckBox.Name = "useFileExtensionCheckBox";
            this.useFileExtensionCheckBox.Size = new System.Drawing.Size(113, 17);
            this.useFileExtensionCheckBox.TabIndex = 3;
            this.useFileExtensionCheckBox.Text = "Use File Extension";
            this.useFileExtensionCheckBox.UseVisualStyleBackColor = true;
            // 
            // textToIgnoreFileNameLabel
            // 
            this.textToIgnoreFileNameLabel.AutoSize = true;
            this.textToIgnoreFileNameLabel.Location = new System.Drawing.Point(117, 20);
            this.textToIgnoreFileNameLabel.Name = "textToIgnoreFileNameLabel";
            this.textToIgnoreFileNameLabel.Size = new System.Drawing.Size(80, 13);
            this.textToIgnoreFileNameLabel.TabIndex = 2;
            this.textToIgnoreFileNameLabel.Text = "Text To Ignore:";
            // 
            // textToIgnoreFileNameTextBox
            // 
            this.textToIgnoreFileNameTextBox.Location = new System.Drawing.Point(203, 17);
            this.textToIgnoreFileNameTextBox.Name = "textToIgnoreFileNameTextBox";
            this.textToIgnoreFileNameTextBox.Size = new System.Drawing.Size(229, 20);
            this.textToIgnoreFileNameTextBox.TabIndex = 1;
            // 
            // useFileNameCheckBox
            // 
            this.useFileNameCheckBox.AutoSize = true;
            this.useFileNameCheckBox.Location = new System.Drawing.Point(6, 19);
            this.useFileNameCheckBox.Name = "useFileNameCheckBox";
            this.useFileNameCheckBox.Size = new System.Drawing.Size(95, 17);
            this.useFileNameCheckBox.TabIndex = 0;
            this.useFileNameCheckBox.Text = "Use File Name";
            this.useFileNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // truncateTableCheckBox
            // 
            this.truncateTableCheckBox.AutoSize = true;
            this.truncateTableCheckBox.Location = new System.Drawing.Point(6, 149);
            this.truncateTableCheckBox.Name = "truncateTableCheckBox";
            this.truncateTableCheckBox.Size = new System.Drawing.Size(99, 17);
            this.truncateTableCheckBox.TabIndex = 11;
            this.truncateTableCheckBox.Text = "Truncate Table";
            this.truncateTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // EditFileTypeModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 550);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.fileTypeGroupBox);
            this.Controls.Add(this.saveFileTypeButton);
            this.Controls.Add(this.footerGroupBox);
            this.Controls.Add(this.columnGroupBox);
            this.Controls.Add(this.headerGroupBox);
            this.Name = "EditFileTypeModal";
            this.Text = "Edit File Type";
            this.headerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerDataGridView)).EndInit();
            this.columnGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnDataGridView)).EndInit();
            this.footerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.footerDataGridView)).EndInit();
            this.fileTypeGroupBox.ResumeLayout(false);
            this.fileTypeGroupBox.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox headerGroupBox;
        private System.Windows.Forms.Button addHeaderButton;
        private System.Windows.Forms.Button removeHeaderButton;
        private System.Windows.Forms.GroupBox columnGroupBox;
        private System.Windows.Forms.Button addColumnButton;
        private System.Windows.Forms.Button removeColumnButton;
        private System.Windows.Forms.GroupBox footerGroupBox;
        private System.Windows.Forms.Button saveFileTypeButton;
        private System.Windows.Forms.Button addFootersButton;
        private System.Windows.Forms.Button removeFootersButton;
        private System.Windows.Forms.DataGridView headerDataGridView;
        private System.Windows.Forms.GroupBox fileTypeGroupBox;
        private System.Windows.Forms.TextBox fileTypeIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox delimiterTextBox;
        private System.Windows.Forms.Label fileTypeDelimiterLabel;
        private System.Windows.Forms.Label fileTypeIDLable;
        private System.Windows.Forms.Label fileTypeNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerName;
        private System.Windows.Forms.DataGridView footerDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn footerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn footerName;
        private System.ComponentModel.BackgroundWorker loadEditFileTypeWorker;
        private System.Windows.Forms.DataGridView columnDataGridView;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.TextBox dateTimeFormatFileExtensionTextBox;
        private System.Windows.Forms.Label dateTimeFormatFileExtensionLabel;
        private System.Windows.Forms.TextBox textToIgnoreFileExtensionTextBox;
        private System.Windows.Forms.Label textToIgnoreFileExtensionLabel;
        private System.Windows.Forms.TextBox dateTimeFormatFileNameTextBox;
        private System.Windows.Forms.Label dateTimeFormatFileNameLabel;
        private System.Windows.Forms.CheckBox useFileExtensionCheckBox;
        private System.Windows.Forms.Label textToIgnoreFileNameLabel;
        private System.Windows.Forms.TextBox textToIgnoreFileNameTextBox;
        private System.Windows.Forms.CheckBox useFileNameCheckBox;
        private System.Windows.Forms.TextBox storedProcedureTextBox;
        private System.Windows.Forms.Label storedProcedureLabel;
        private System.Windows.Forms.Label dateTimeColumnLabel;
        private System.Windows.Forms.CheckBox linkDateTimeCheckBox;
        private System.Windows.Forms.TextBox dateTimeColumnTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ignoreColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn notInFileColumn;
        private System.Windows.Forms.CheckBox truncateTableCheckBox;
    }
}