using DBapplication;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ophthalmic_Clinic
{
    public partial class Admin : Form
    {
        Controller controlobj;
        public Admin()
        {
            InitializeComponent();
            controlobj = new Controller();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int result = controlobj.InsertDepartment(textBox1.Text, textBox2.Text, textBox3.Text);
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    MessageBox.Show("rows are inserted successfully");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int result = controlobj.UpdateDepartment(textBox4.Text, textBox5.Text, textBox6.Text);
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else if (result == -1)
                {
                    MessageBox.Show("No head with this ID");
                }
                else
                {
                    MessageBox.Show("rows are updated successfully");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int result = controlobj.DeleteDepartment(textBox7.Text);
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    MessageBox.Show("rows are updated successfully");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 0 || textBox9.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int result = controlobj.UpdateDepartmentHead(textBox9.Text, textBox8.Text);
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    MessageBox.Show("rows are updated successfully");
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Length == 0 || textBox11.Text.Length == 0 || textBox12.Text.Length == 0 || textBox13.Text.Length == 0 || textBox14.Text.Length == 0 || textBox15.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int result = controlobj.AddDoctor(textBox10.Text, textBox11.Text, textBox12.Text, Int32.Parse(textBox13.Text), textBox14.Text, textBox15.Text);
                if (result == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    MessageBox.Show("rows are updated successfully");
                }
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox16.Text.Length == 0 || textBox17.Text.Length == 0 || textBox18.Text.Length == 0 || textBox19.Text.Length == 0 || textBox20.Text.Length == 0 || textBox21.Text.Length == 0 || textBox22.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.InsertEmployeee(textBox16.Text, textBox17.Text, textBox18.Text, Int32.Parse(textBox19.Text), textBox22.Text, textBox20.Text, textBox21.Text);
                if (r == 0)
                {
                    MessageBox.Show("No rows are updated");
                }
                else
                {
                    MessageBox.Show("rows are updated successfully");
                }
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox23.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.DeleteEmployee(textBox23.Text);
                if (r == 0)
                {
                    MessageBox.Show("No rows are deleted!");
                }
                else
                {
                    MessageBox.Show("Employee is deleted successfully!");
                }
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox24.Text.Length == 0)
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.DeleteDoctor(textBox24.Text);
                if (r == 0)
                {
                    MessageBox.Show("No rows are deleted!");
                }
                else
                {
                    MessageBox.Show("Doctor is deleted successfully!");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}