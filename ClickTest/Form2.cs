using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTest
{
    public partial class Form2 : Form
    {
        public int clicks;
        public int time;
        public float cps;

        public Form2(Form1 Form1)
        {
            clicks = Form1.count;
            time = Form1.startingTime;
            cps = clicks / (time - 0.0f);
            InitializeComponent();
            label1.Text = "Total clicks: " + clicks + "\nAverage CPS:" + cps + "\nTime: " + time;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            Form3 newForm = new Form3();
            foreach (Form frm in fc)
            {
                if (frm.Name == newForm.Name)
                {
                    frm.Close();
                    break;
                }
            }
            //open saved results
            newForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save results
            var path = @"..\..\Data\Data.csv";
            var date = DateTime.Now;
            var line = '\n' + date.ToString() + ";" + clicks + ";" + time + ";" + cps;
            File.AppendAllText(path, line);
            button3.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
