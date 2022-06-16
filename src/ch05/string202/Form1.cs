using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            int result = text1.CompareTo(text2);
            if ( result == 0 )
            {
                label4.Text = "同じです。";
            } 
            else if ( result < 0 )
            {
                label4.Text = $"{text1} のほうが小さい";
            }
            else
            {
                label4.Text = $"{text1} のほうが大きい";
            }
        }
    }
}
