using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg115
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = checkBox1.Checked && checkBox2.Checked;
            label1.Text = $"演算結果 : {result}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool result = checkBox1.Checked || checkBox2.Checked;
            label1.Text = $"演算結果 : {result}";
        }
    }
}
