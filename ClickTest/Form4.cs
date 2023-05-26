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

namespace WindowsFormsAppTest
{
    public partial class Form4 : Form
    {
        private DateTime _startingDateTime = DateTime.Now.AddHours(-1);
        enum ChartType
        {
            DateClicks,
            DateCPS
        }

        ChartType chartType;
        private readonly string[][] _data;
        public Form4(string[][] data)
        {
            InitializeComponent();
            _data = data;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Series series in chart1.Series)
            {
                series.Points.Clear();
            }
            foreach (string[] values in _data.Skip(1))
            {
                DateTime dateTime = Convert.ToDateTime(values[0]);
                if (dateTime < _startingDateTime)
                {
                    continue;
                }
                int clicks = Convert.ToInt32(values[1]);
                float time = Convert.ToSingle(values[2]);
                float cps = Convert.ToSingle(values[3]);
                chart1.Series["Clicks"].Points.Add(clicks);
                chart1.Series["CPS"].Points.Add(cps);
                chart1.Series["Time"].Points.Add(time);
            }
        }

        private void ClicksDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = ClicksDateCheckBox.Checked;
            Form4_Load(this, EventArgs.Empty);
        }

        private void CPSDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = CPSDateCheckBox.Checked;
            Form4_Load(this, EventArgs.Empty);
        }
        private void TimeDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Enabled = TimeDateCheckBox.Checked;
        }

        #region TimeIntervarRadioButtons
        private void TimeIntervalButton_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.Now.AddHours(-1);
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.Now.AddDays(-1);
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.Now.AddDays(-7);
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.Now.AddMonths(-1);
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.Now.AddYears(-1);
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _startingDateTime = DateTime.MinValue;
            Form4_Load(this, EventArgs.Empty);

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = radioButton6.Checked;
            dateTimePicker1.Visible = radioButton6.Checked;
            _startingDateTime = dateTimePicker1.Value;
            Form4_Load(this, EventArgs.Empty);
        }
        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _startingDateTime = dateTimePicker1.Value;
            Form4_Load(this, EventArgs.Empty);
        }

    }
}
