namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    partial class AddHeaderModal
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
            this.headerNameLablel = new System.Windows.Forms.Label();
            this.headerNameTextBox = new System.Windows.Forms.TextBox();
            this.saveHeaderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerNameLablel
            // 
            this.headerNameLablel.AutoSize = true;
            this.headerNameLablel.Location = new System.Drawing.Point(12, 39);
            this.headerNameLablel.Name = "headerNameLablel";
            this.headerNameLablel.Size = new System.Drawing.Size(76, 13);
            this.headerNameLablel.TabIndex = 0;
            this.headerNameLablel.Text = "Header Name:";
            this.headerNameLablel.Click += new System.EventHandler(this.label1_Click);
            // 
            // headerNameTextBox
            // 
            this.headerNameTextBox.Location = new System.Drawing.Point(94, 36);
            this.headerNameTextBox.Name = "headerNameTextBox";
            this.headerNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.headerNameTextBox.TabIndex = 1;
            // 
            // saveHeaderButton
            // 
            this.saveHeaderButton.Location = new System.Drawing.Point(256, 74);
            this.saveHeaderButton.Name = "saveHeaderButton";
            this.saveHeaderButton.Size = new System.Drawing.Size(75, 23);
            this.saveHeaderButton.TabIndex = 2;
            this.saveHeaderButton.Text = "Add";
            this.saveHeaderButton.UseVisualStyleBackColor = true;
            this.saveHeaderButton.Click += new System.EventHandler(this.saveHeaderButton_Click);
            // 
            // AddHeaderModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 109);
            this.Controls.Add(this.saveHeaderButton);
            this.Controls.Add(this.headerNameTextBox);
            this.Controls.Add(this.headerNameLablel);
            this.Name = "AddHeaderModal";
            this.Text = "AddHeaderModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerNameLablel;
        private System.Windows.Forms.TextBox headerNameTextBox;
        private System.Windows.Forms.Button saveHeaderButton;
    }
}