using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.CodeDom.Compiler;

namespace Ophthalmic_Clinic
{
    public partial class viewappointmentrequest : Form
    {
        Controller controlobj;
        public viewappointmentrequest()
        {
            InitializeComponent();
            controlobj = new Controller();
            DataTable dt1 = controlobj.getDoctorID();
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "DoctorID";

            DataTable dt10 = controlobj.getRequestID();
            comboBox3.DataSource = dt10;
            comboBox3.DisplayMember = "RequestID";


            DataTable dt = controlobj.returnSlots();
            dataGridView1.DataSource = dt;

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.Refresh();



            DataTable dt3 = controlobj.ReturnRequests();
            dataGridView2.DataSource = dt3;
            dataGridView2.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Receptionist r = new Receptionist(null);
            r.Show();
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Name = "Slot 1";
            dataGridView1.Columns[1].Name = "Slot 2";
            dataGridView1.Columns[2].Name = "Slot 3";
            dataGridView1.Columns[3].Name = "Slot 4";
            dataGridView1.Columns[4].Name = "Slot 5";
            dataGridView1.Columns[5].Name = "Slot 6";

            dataGridView1.RowHeadersVisible = true;

            DataTable data = controlobj.getDoctorID();
            int i = 0;

            foreach (DataRow row in data.Rows)
            {
                dataGridView1.Rows[i].HeaderCell.Value = row["DoctorID"].ToString();
                i++;
            }

        }

        private void viewappointmentrequest_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = controlobj.UpdateAppointmentReception(comboBox2.Text, comboBox1.Text,true, comboBox3.Text);
            if (result == 0)
            {
                MessageBox.Show("No rows are updated");
            }
            else if (result == -1)
            {
                MessageBox.Show("Time slot is already taken");
            }
            else
            {
                DataTable dt = controlobj.returnSlots();
                dataGridView1.DataSource = dt;

                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
                dataGridView1.Refresh();


                DataTable dt3 = controlobj.ReturnRequests();
                dataGridView2.DataSource = dt3;
                dataGridView2.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = controlobj.UpdateAppointmentReception(comboBox2.Text, comboBox1.Text,false,comboBox3.Text);
            if (result == 0)
            {
                MessageBox.Show("No rows are updated");
            }
            else if (result == -1)
            {
                MessageBox.Show("Time slot is already not taken");
            }
            else
            {
                DataTable dt = controlobj.returnSlots();
                dataGridView1.DataSource = dt;

                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
                dataGridView1.Refresh();

                DataTable dt3 = controlobj.ReturnRequests();
                dataGridView2.DataSource = dt3;
                dataGridView2.Refresh();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
