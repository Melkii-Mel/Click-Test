using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTest
{
    public partial class Form1 : Form
    {
        public int count = 0;
        public int time = 1;
        public int actualTime;
        public bool isActive = false;
        public int startingTime;
        public int counter = 0;
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = time.ToString() + " Secs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualTime --;
            try
            {
                textBox2.Text = "KPS: " + Math.Round((count / (startingTime - time + 0.0f)), 3).ToString();
            }
            catch (DivideByZeroException)
            {
                textBox2.Text = "N/A";
            }
            
            if ((actualTime + 0.0f) / 10 < time)
            {
                time --;
            }
            label1.Text = time.ToString() + " Secs";
            
            if (time == -1)
            {
                timer1.Enabled = false;
                label1.Text = "Time ran out!";
                button1.Enabled = false;
                Form2 newForm = new Form2(this);
                newForm.ShowDialog();
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time ++;
            label1.Text = time.ToString() + " Secs";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (time > 1) { time--; }
            label1.Text = time.ToString() + " Secs";
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            count++;
            textBox1.AppendText("Klick Count: " + count.ToString());
            if (isActive == false)
            {
                timer1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                actualTime = time * 10;
                isActive = true;
                startingTime = time;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            time = startingTime;
            actualTime = 0;
            isActive = false;
            count = 0;
            label1.Text = time.ToString() + " Secs";
            button4.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}