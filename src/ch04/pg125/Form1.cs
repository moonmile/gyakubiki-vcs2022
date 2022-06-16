using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg125
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt1 = DateTime.Now;
            var dt2 = dt1.ToUniversalTime();
            label3.Text = dt1.ToString();
            label4.Text = dt2.ToString();
            label5.Text = dt1.ToString("zzz");
        }
    }
}
