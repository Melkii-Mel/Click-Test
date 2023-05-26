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
        private string[][] _data;
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
            _data = File.ReadAllLines(path)
            .Select(line => line.Split(';').ToArray())
            .ToArray();
            for (int i = 0; i < _data[0].Count(); i++)
            {
                dataGridView1.Columns.Add(_data[0][i], _data[0][i]);
            }
            for (int i = 1; i < _data.Count(); i++)
            {
                dataGridView1.Rows.Add(_data[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(_data);
            form4.ShowDialog();
        }
    }
}
