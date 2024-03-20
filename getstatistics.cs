﻿using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ophthalmic_Clinic
{
    public partial class getstatistics : Form
    {
        Controller controlobj;
        public getstatistics()
        {
            InitializeComponent();
            controlobj = new Controller();



            DataTable data = controlobj.getnumber();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill; // Change the DockStyle to fill a specific panel within the DataGridView

            // Create a new chart area.
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "ChartArea1";

            // Add the chart area to the chart.
            chart.ChartAreas.Add(chartArea);

            // Add a series to the chart.
            Series series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in data.Rows)
            {
                string label = row["DoctorID"].ToString();
                int value = Convert.ToInt32(row["NumberOfPatients"]);
                series.Points.AddXY(label, value);
            }

            // Add the series to the chart.
            chart.Series.Add(series);

            // Add the chart to the form.
            this.Controls.Add(chart);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Receptionist r = new Receptionist(null);
            r.Show();
        }

        private void getstatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
