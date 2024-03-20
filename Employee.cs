using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ophthalmic_Clinic
{
    public partial class Employee : Form
    {
        Controller controlobj;
        public Employee()
        {
            InitializeComponent();
            controlobj = new Controller();
            DataTable dt = controlobj.SelectStockAvailable();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Item_Name";


            DataTable dt2 = controlobj.ShowDataStock();
            dataGridView1.DataSource = dt2;

            dataGridView1.CellFormatting += dataGridView_CellFormatting;
            dataGridView1.Refresh();
        }

        


        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];
                int itemQty = Convert.ToInt32(row.Cells["Item_Qty"].Value);
                int minQty = Convert.ToInt32(row.Cells["Minimum_Qty_Acc"].Value);

                if (itemQty < minQty)
                {
                    // Set the cell's foreground color to red
                    cell.Style.ForeColor = Color.Red;
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                    MessageBox.Show("Please, insert all values");
            else
            {
                int result = controlobj.UpdateStock(comboBox1.Text, Int32.Parse(textBox1.Text));
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    DataTable dt = controlobj.ShowDataStock();
                    dataGridView1.DataSource = dt;

                    dataGridView1.CellFormatting += dataGridView_CellFormatting;
                    dataGridView1.Refresh();
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome p = new Welcome();
            p.Show();
        }
    }
}
