using ethosIQ_File_Reader_Shared.FileConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ethosIQ_File_Reader_Tool.FileTypeModal
{
    public partial class AddHeaderModal : Form
    {
        private DataGridView DataGridView;

        public AddHeaderModal(ref DataGridView DataGridView)
        {
            InitializeComponent();
            this.DataGridView = DataGridView;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveHeaderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Header header = new Header();

                if (headerNameTextBox.Text != "")
                {
                    header = new Header(DataGridView.Rows.Count, headerNameTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Header name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridView.Invoke(new Action(() => DataGridView.Rows.Add(header.HeaderNumber, header.HeaderName)));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed To Add Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
