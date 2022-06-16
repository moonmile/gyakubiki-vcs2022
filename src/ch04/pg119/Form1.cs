using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg119
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            label5.Text = dt.ToString();
            label6.Text = dt.Year.ToString();
            label7.Text = dt.Month.ToString();
            label8.Text = dt.Day.ToString();
        }
    }
}
