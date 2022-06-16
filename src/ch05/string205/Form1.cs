using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string205
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            label5.Text = "[" + text.Trim() + "]";
            label6.Text = "[" + text.TrimStart()+"]";
            label7.Text = "[" + text.TrimEnd()+ "]";
        }
    }
}
