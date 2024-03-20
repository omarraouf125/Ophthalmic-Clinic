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
    public partial class GetPatientBills : Form
    {
        Controller controlObj;
        public GetPatientBills()
        {
            InitializeComponent();
            controlObj = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Patients' ID");
            }
            else if (Convert.ToInt32(textBox1.Text) < 0)
            {
                MessageBox.Show("Please enter a valid ID");
            }

            else
            {
                DataTable r = controlObj.checkPatientID(textBox1.Text);
                if (r == null)
                {
                    MessageBox.Show("There is no patient with this id");
                }
                else
                {
                    DataTable dt = controlObj.Getbills(textBox1.Text);
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    if (dt == null)
                        MessageBox.Show("No Bills found for this patient");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Patients' ID");
            }
            else if (Convert.ToInt32(textBox1.Text) < 0)
            {
                MessageBox.Show("Please enter a valid ID");
            }

            else
            {
                DataTable r = controlObj.checkPatientID(textBox1.Text);
                if (r == null)
                {
                    MessageBox.Show("There is no patient with this id");
                }
                else
                {
                    DataTable dt = controlObj.Gettotalbill(textBox1.Text);
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    if (dt == null)


                        MessageBox.Show("No Bills found for this patient");

                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Patients' ID");
            }
            else if (Convert.ToInt32(textBox1.Text) < 0)
            {
                MessageBox.Show("Please enter a valid ID");
            }

            else
            {
                DataTable r = controlObj.checkPatientID(textBox1.Text);
                if (r == null)
                {
                    MessageBox.Show("There is no patient with this id");
                }
                else
                {
                    DataTable dt = controlObj.Gettotalbill(textBox1.Text);
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    if (dt == null)


                        MessageBox.Show("No Bills found for this patient");

                }
            }
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Receptionist r = new Receptionist(null);
            r.Show();

        }

        
    }
}
