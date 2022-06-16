using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string212
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            var rx = new Regex("[様君殿行]$");
            label3.Text = rx.Replace(text, "御中");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            label3.Text =Regex.Replace(text, "[様君殿行]$","御中");
        }
    }
}
