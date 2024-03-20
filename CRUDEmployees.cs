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
    public partial class CRUDEmployees : Form
    {
        Controller controlobj;
        public CRUDEmployees()
        {
            InitializeComponent();
            controlobj = new Controller();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox8.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.InsertEmployeee(textBox1.Text, textBox2.Text, textBox3.Text, Int16.Parse(textBox4.Text), textBox5.Text, textBox6.Text, textBox8.Text);
                if (r == 0)
                {
                    MessageBox.Show("Failed To Insert");
                }
                else
                    MessageBox.Show("Employee's account created succesfully!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox8.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.UpdateEmployee(textBox1.Text, textBox2.Text, textBox3.Text, Int16.Parse(textBox4.Text), textBox5.Text, textBox6.Text, textBox8.Text);
                if (r == 0)
                {
                    MessageBox.Show("Failed To Update");
                }
                else
                    MessageBox.Show("Employee's account updated succesfully!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = controlobj.GetEmployeeData(textBox9.Text);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.DeleteEmployee(textBox9.Text);
                if (r == 0)
                {
                    MessageBox.Show("Failed To Delete");
                }
                else
                    MessageBox.Show("Employee's account Deleted succesfully!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome p = new Welcome();
            p.Show();
        }
    }
}