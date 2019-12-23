namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    partial class AddColumnModal
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
            this.columnNameLabel = new System.Windows.Forms.Label();
            this.databaseColumnNameLabel = new System.Windows.Forms.Label();
            this.columnNameTextBox = new System.Windows.Forms.TextBox();
            this.databaseColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.saveColumnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // columnNameLabel
            // 
            this.columnNameLabel.AutoSize = true;
            this.columnNameLabel.Location = new System.Drawing.Point(63, 19);
            this.columnNameLabel.Name = "columnNameLabel";
            this.columnNameLabel.Size = new System.Drawing.Size(76, 13);
            this.columnNameLabel.TabIndex = 0;
            this.columnNameLabel.Text = "Column Name:";
            this.columnNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // databaseColumnNameLabel
            // 
            this.databaseColumnNameLabel.AutoSize = true;
            this.databaseColumnNameLabel.Location = new System.Drawing.Point(12, 55);
            this.databaseColumnNameLabel.Name = "databaseColumnNameLabel";
            this.databaseColumnNameLabel.Size = new System.Drawing.Size(125, 13);
            this.databaseColumnNameLabel.TabIndex = 1;
            this.databaseColumnNameLabel.Text = "Database Column Name:";
            // 
            // columnNameTextBox
            // 
            this.columnNameTextBox.Location = new System.Drawing.Point(145, 16);
            this.columnNameTextBox.Name = "columnNameTextBox";
            this.columnNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.columnNameTextBox.TabIndex = 2;
            // 
            // databaseColumnNameTextBox
            // 
            this.databaseColumnNameTextBox.Location = new System.Drawing.Point(145, 52);
            this.databaseColumnNameTextBox.Name = "databaseColumnNameTextBox";
            this.databaseColumnNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.databaseColumnNameTextBox.TabIndex = 3;
            this.databaseColumnNameTextBox.TextChanged += new System.EventHandler(this.databaseColumnNameTextBox_TextChanged);
            // 
            // saveColumnButton
            // 
            this.saveColumnButton.Location = new System.Drawing.Point(256, 81);
            this.saveColumnButton.Name = "saveColumnButton";
            this.saveColumnButton.Size = new System.Drawing.Size(75, 23);
            this.saveColumnButton.TabIndex = 4;
            this.saveColumnButton.Text = "Add";
            this.saveColumnButton.UseVisualStyleBackColor = true;
            this.saveColumnButton.Click += new System.EventHandler(this.saveColumnButton_Click);
            // 
            // AddColumnModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 116);
            this.Controls.Add(this.saveColumnButton);
            this.Controls.Add(this.databaseColumnNameTextBox);
            this.Controls.Add(this.columnNameTextBox);
            this.Controls.Add(this.databaseColumnNameLabel);
            this.Controls.Add(this.columnNameLabel);
            this.Name = "AddColumnModal";
            this.Text = "Add Column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label columnNameLabel;
        private System.Windows.Forms.Label databaseColumnNameLabel;
        private System.Windows.Forms.TextBox columnNameTextBox;
        private System.Windows.Forms.TextBox databaseColumnNameTextBox;
        private System.Windows.Forms.Button saveColumnButton;
    }
}