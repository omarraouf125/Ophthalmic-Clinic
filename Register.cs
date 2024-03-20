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
    public partial class Register : Form
    {
        Controller controlobj;
        public Register()
        {
            InitializeComponent();
            controlobj = new Controller();
        }


        private void register_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("Please, insert all values");
            else
            {
                int r = controlobj.RegisterPatient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Int32.Parse(textBox5.Text), textBox6.Text);
                if (r == 0)
                {
                    MessageBox.Show("Username already exits, try another one");
                }
                else
                {
                    MessageBox.Show("Registered successfully! Click on Go Back to Log In");
                }
            }
            
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show(); 
            this.Close();
        }
    }
}
