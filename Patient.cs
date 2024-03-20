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

namespace Ophthalmic_Clinic
{
    public partial class Patient : Form
    {
        Controller controlobj;
        string pid;
        public Patient(string id)
        {
            InitializeComponent();
            controlobj = new Controller();
            pid = id;
        }



        private void ChngPass_button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = controlobj.RequestAppointments(pid);
            if (r == 0)
            {
                MessageBox.Show("Couldn't Request an Appointment, please try again!");
            }
            else
            {
                MessageBox.Show("Appointment Requested Successfully!");
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void ProvFeed_butoon_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DataTable dt = controlobj.Healthrecords(pid);
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            else
                MessageBox.Show("No Medical Records are registered yet!");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DataTable dt = controlobj.review_services_off();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void Submit_button_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                    MessageBox.Show("Please, insert all values");
            else
            {
                int r = controlobj.FeedBacks(pid, richTextBox1.Text);
                if (r == 0)
                {
                    MessageBox.Show("Failed To Send FeedBack, Please Try Again");
                }
                else
                {
                    MessageBox.Show("FeedBack Sent Successfully");
                }
            }
            
        }

        private void ChngPass_button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please, insert all values");
            else
            {
                if (textBox1.Text == textBox2.Text)
                {
                    int r = controlobj.UpdatePersInfo(pid, textBox2.Text);
                    if (r == 0)
                    {
                        MessageBox.Show("Failed to change password");
                    }
                    else
                    {
                        MessageBox.Show("Password updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords Don't Match");
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DataTable dt = controlobj.GetRequestedAppointmenst(pid);
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            else
                MessageBox.Show("No Medical Records are registered yet!");
        }
    }
}