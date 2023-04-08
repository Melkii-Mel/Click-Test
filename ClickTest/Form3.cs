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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"..\..\Data\Data.csv";
            var path = Path.Combine(appDir, relativePath);
            var data = File.ReadAllLines(path)
            .Select(line => line.Split(';').ToArray())
            .ToArray();
            for (int i = 0; i < data[0].Count(); i++)
            {
                dataGridView1.Columns.Add(data[0][i], data[0][i]);
            }
            for (int i = 1; i < data.Count(); i++)
            {
                dataGridView1.Rows.Add(data[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
