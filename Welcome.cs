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
    public partial class Welcome : Form
    {
        Controller ControlObj;
        public Welcome()
        {
            InitializeComponent();
            ControlObj = new Controller();
        }


        private void register_button_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please, insert all values");
            else
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    Admin a = new Admin();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    DataTable dt = ControlObj.LogIn(textBox1.Text, textBox2.Text);
                    DataTable dt2 = ControlObj.LogIn2(textBox1.Text, textBox2.Text);
                    if (dt == null && dt2 == null)
                    {
                        MessageBox.Show("Enter ID and Password correctly");
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                    }
                    else if (dt2 != null)
                    {

                        Receptionist r = new Receptionist(textBox1.Text);
                        r.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                    }
                    else if (Convert.ToString(dt.Rows[0][0]) == "Patient" && Convert.ToInt32(dt.Rows[0][1]) == Int32.Parse(textBox1.Text) && Convert.ToString(dt.Rows[0][2]) == textBox2.Text)
                    {
                        Patient p = new Patient(Convert.ToString(dt.Rows[0][1]));
                        p.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();

                    }
                    else if (Convert.ToString(dt.Rows[0][0]) == "Doctor" && Convert.ToInt32(dt.Rows[0][1]) == Int32.Parse(textBox1.Text) && Convert.ToString(dt.Rows[0][2]) == textBox2.Text)
                    {
                        Doctor d = new Doctor(Convert.ToString(dt.Rows[0][1]));
                        d.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();

                    }
                    else if (Convert.ToString(dt.Rows[0][0]) == "Employee" && Convert.ToInt32(dt.Rows[0][1]) == Int32.Parse(textBox1.Text) && Convert.ToString(dt.Rows[0][2]) == textBox2.Text)
                    {
                        Employee E = new Employee();
                        E.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();

                    }
                }

            }

            



        }
    }
}
