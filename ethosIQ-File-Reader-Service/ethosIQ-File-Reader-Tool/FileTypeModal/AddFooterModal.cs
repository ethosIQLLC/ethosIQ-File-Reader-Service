using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Windows.Forms;

namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    public partial class AddFooterModal : Form
    {
        private DataGridView DataGridView;

        public AddFooterModal(ref DataGridView DataGridView)
        {
            InitializeComponent();
            this.DataGridView = DataGridView;
        }

        private void saveHeaderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Footer footer = new Footer();

                if (footerNameTextBox.Text != "")
                {
                    footer = new Footer(DataGridView.Rows.Count, footerNameTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Header name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridView.Invoke(new Action(() => DataGridView.Rows.Add(footer.FooterNumber, footer.FooterName)));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed To Add Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
