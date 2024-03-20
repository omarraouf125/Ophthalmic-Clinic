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
    public partial class DepartmentHead : Form
    {
        Controller controlobj;
        string doctorid;
        public DepartmentHead(string d)
        {
            InitializeComponent();
            controlobj = new Controller();
            doctorid = d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDEmployees emp = new CRUDEmployees();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                DataTable dt = controlobj.GetTechPhone(textBox1.Text);
                if (dt == null)
                {
                    MessageBox.Show("No technicians available for this equipment");
                }
                else
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Doctor d = new Doctor(doctorid);
            d.Show();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockReport p = new StockReport();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalaryReport p = new SalaryReport();
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.AddService(textBox2.Text, textBox3.Text);
                if (r == 0)
                {
                    MessageBox.Show("Service already exists");
                }
                else
                {
                    MessageBox.Show("Service added successfully");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            DoctorCountReport p = new DoctorCountReport();
            p.Show();
        }
    }
}