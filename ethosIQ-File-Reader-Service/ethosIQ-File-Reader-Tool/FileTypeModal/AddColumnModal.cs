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
    public partial class AddColumnModal : Form
    {
        public DataGridView DataGridView;

        public AddColumnModal(ref DataGridView DataGridView)
        {
            InitializeComponent();
            this.DataGridView = DataGridView;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveColumnButton_Click(object sender, EventArgs e)
        {
            try
            {
                Column column = new Column();

                column.ColumnNumber = DataGridView.Rows.Count;

                if (columnNameTextBox.Text != "")
                {
                    column.ColumnName = columnNameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Column name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(databaseColumnNameTextBox.Text != "")
                {
                    column.DatabaseColumnName = databaseColumnNameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Database column name cannot be an empty string.", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridView.Invoke(new Action(() => DataGridView.Rows.Add(column.ColumnNumber, column.ColumnName, column.DatabaseColumnName)));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, " Failed To Add Column!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseColumnNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
