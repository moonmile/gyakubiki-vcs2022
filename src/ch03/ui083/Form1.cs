using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui083
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// decimal型をint型にキャストする
            int num = (int)numericUpDown1.Value;
            label1.Text = $"入力した数値は {num} です";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 50;
            numericUpDown1.Increment = 10;
        }
    }
}
