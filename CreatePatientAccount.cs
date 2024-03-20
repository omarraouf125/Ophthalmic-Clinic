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
    public partial class CreatePatientAccount : Form
    {
        Controller controlObj;
        public CreatePatientAccount()
        {
            InitializeComponent();
            controlObj = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all fields ");
            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please choose gender ");
            }
            else if (Convert.ToInt32(textBox4.Text) <= 0)
            {
                MessageBox.Show("Age should be a positive number ");
            }
            else
            {
                int r = controlObj.createpatientaccount(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), getradiobuttonvalue());

                if (r == 0)
                {
                    MessageBox.Show("The ID inserted already exists,please insert another one ");
                }
                else
                    MessageBox.Show("Patient's account created succesfully ");
            }

            string getradiobuttonvalue()
            {
                if (radioButton1.Checked)
                    return radioButton1.Text;

                return radioButton2.Text;
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
