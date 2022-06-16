using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg122
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
            label6.Text = dt.ToString();
            label7.Text = dt.AddDays(10).ToLongDateString();
            label8.Text = dt.AddHours(-5).ToString();
            label9.Text = new DateTime(dt.Year, dt.Month, 1)
                .AddMonths(1).AddDays(-1).ToLongDateString();
            label10.Text = new DateTime(dt.Year, dt.Month, 1)
                .AddDays(-1).ToLongDateString();
        }
    }
}
