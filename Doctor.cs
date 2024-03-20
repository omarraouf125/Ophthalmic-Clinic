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
    public partial class Doctor : Form
    {
        Controller controlobj;
        string doctorid;
        public Doctor(string id)
        {
            InitializeComponent();
            controlobj = new Controller();
            doctorid = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox3.Text == "")
            {

            }
            int r = controlobj.InsertMedicalRecord(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, doctorid, textBox3.Text);
            if (r == 0)
            {
                MessageBox.Show("Failed to update");
            }
            else
            {
                MessageBox.Show("Medical Record Inserted Successfully!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                controlobj.UpdateslotOne(1, doctorid);
            }

            if (checkBox1.Checked == false)
            {
                controlobj.UpdateslotOne(0, doctorid);
            }
            if (checkBox2.Checked == true)
            {

                controlobj.UpdateslotTwo(1, doctorid);
            }

            if (checkBox2.Checked == false)
            {
                controlobj.UpdateslotTwo(0, doctorid);
            }

            if (checkBox3.Checked == true)
            {

                controlobj.UpdateslotThree(1, doctorid);
            }

            if (checkBox3.Checked == false)
            {
                controlobj.UpdateslotThree(0, doctorid);
            }
            if (checkBox4.Checked == true)
            {

                controlobj.UpdateslotFour(1, doctorid);
            }

            if (checkBox4.Checked == false)
            {
                controlobj.UpdateslotFour(0, doctorid);
            }
            if (checkBox5.Checked == true)
            {

                controlobj.UpdateslotFive(1, doctorid);
            }

            if (checkBox5.Checked == false)
            {
                controlobj.UpdateslotFive(0, doctorid);
            }
            if (checkBox6.Checked == true)
            {

                controlobj.UpdateslotSix(1, doctorid);
            }

            if (checkBox6.Checked == false)
            {
                controlobj.UpdateslotSix(0, doctorid);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome p = new Welcome();
            p.Show();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Please Write the data required");
            }
            else
            {
                int r = controlobj.ChangeDoctorPassword(textBox10.Text, doctorid);
                if (r == 0)
                {
                    MessageBox.Show("Failed to update password");
                }
                else
                {
                    MessageBox.Show("Password Updated Successfully");
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DataTable dt = controlobj.CheackDepartHead(doctorid);
            if (dt == null)
            {
                MessageBox.Show("You are not a Department Head to access");
            }
            else
            {
                DepartmentHead dh = new DepartmentHead(doctorid);
                dh.Show();
                this.Close();
            }

        }



        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "1");
            }
            if (checkBox7.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "1");
            }
            if (checkBox8.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "2");
            }
            if (checkBox8.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "2");
            }
            if (checkBox9.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "3");
            }
            if (checkBox9.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "3");
            }
            if (checkBox10.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "4");
            }
            if (checkBox10.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "4");
            }
            if (checkBox11.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "5");
            }
            if (checkBox11.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "5");
            }
            if (checkBox12.Checked == true)
            {
                controlobj.UpdatesSurgeryRoom(1, comboBox1.Text, "6");
            }
            if (checkBox12.Checked == false)
            {
                controlobj.UpdatesSurgeryRoom(0, comboBox1.Text, "6");
            }
        }


    }
}