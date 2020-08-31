using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderFiles
{
    public partial class Form1 : Form
    {
        public static DateTime d1 = new DateTime();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>()
            {
                "txt",
                "png",
                "jpeg",
                "jpg"
            };           
            PrintExtensions(list);          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = (fbd.SelectedPath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = (fbd.SelectedPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            d1 = DateTime.Now;
            timer1.Tick += new EventHandler(PrintInfo);
            timer1.Enabled = true;

            Model m = new Model(textBox1.Text, textBox2.Text, textBox3.Text);
            Thread t1 = new Thread(StartApp);
            t1.Start();

        }

        private void StartApp()
        {
            Controller c = new Controller();
        
            Model m = new Model(textBox1.Text, textBox2.Text, textBox3.Text);
            c.CopyFiles(m);

            PrintSuccess();
        }


        internal void PrintExtensions(List<string> list)
        {
            string res = string.Join(",", list);
            textBox3.Text =  res;
        }

        internal void PrintInfo(Object myObject, EventArgs myEventArgs)
        {
            DateTime d2 = DateTime.Now;
            TimeSpan result = d2.Subtract(d1);
            textBox4.Text = "App running for " + Math.Round(result.TotalSeconds).ToString() + " seconds";
        }

        internal void PrintSuccess()
        {
            timer1.Enabled = false;
            MessageBox.Show("Successfully completed!");
        }

        internal void PrintPathError()
        {
            MessageBox.Show("Please enter valid Path \nand make sure Extensions are not empty");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}



