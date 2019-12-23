namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    partial class AddFooterModal
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
            this.footerNameLablel = new System.Windows.Forms.Label();
            this.footerNameTextBox = new System.Windows.Forms.TextBox();
            this.saveHeaderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // footerNameLablel
            // 
            this.footerNameLablel.AutoSize = true;
            this.footerNameLablel.Location = new System.Drawing.Point(12, 39);
            this.footerNameLablel.Name = "footerNameLablel";
            this.footerNameLablel.Size = new System.Drawing.Size(71, 13);
            this.footerNameLablel.TabIndex = 0;
            this.footerNameLablel.Text = "Footer Name:";
            // 
            // footerNameTextBox
            // 
            this.footerNameTextBox.Location = new System.Drawing.Point(94, 36);
            this.footerNameTextBox.Name = "footerNameTextBox";
            this.footerNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.footerNameTextBox.TabIndex = 1;
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
            // AddFooterModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 109);
            this.Controls.Add(this.saveHeaderButton);
            this.Controls.Add(this.footerNameTextBox);
            this.Controls.Add(this.footerNameLablel);
            this.Name = "AddFooterModal";
            this.Text = "Add Footer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label footerNameLablel;
        private System.Windows.Forms.TextBox footerNameTextBox;
        private System.Windows.Forms.Button saveHeaderButton;
    }
}