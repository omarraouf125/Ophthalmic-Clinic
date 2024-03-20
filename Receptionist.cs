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
    public partial class Receptionist : Form
    {
        Controller controlObj;
        string rid;
        public Receptionist(string id)
        {
            InitializeComponent();
            controlObj = new Controller();
            rid = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CreatePatientAccount p = new CreatePatientAccount();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            GetPatientBills p = new GetPatientBills();
            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            getstatistics p=new getstatistics();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            viewappointmentrequest r=new viewappointmentrequest();
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("please enter new password value");
            }
            int r = controlObj.changereceptionistpass(textBox1.Text,rid);
            if (r==0)
            {
                MessageBox.Show("couldn't change password");

            }
            else 
            {
         
                MessageBox.Show("Password Changed!");

            }

        }

       

        private void button7_Click_1(object sender, EventArgs e)
        {
            CostReport p = new CostReport();
            p.Show();
        }
    }
}
