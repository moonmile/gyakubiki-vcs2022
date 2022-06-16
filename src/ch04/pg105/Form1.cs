using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg105
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n = 123.45;
            int m = 10000;

            label5.Text = n.ToString(); 
            label6.Text = m.ToString("#,###円");
            label7.Text = n.ToString("#.###");
            label8.Text = n.ToString("0.000");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double n = 123.45;
            int m = 10000;

            label5.Text = $"{n}";
            label6.Text = $"{m:#,###}円";
            label7.Text = $"{n:#.###}";
            label8.Text = $"{n:#0.000}";

        }
    }
}
