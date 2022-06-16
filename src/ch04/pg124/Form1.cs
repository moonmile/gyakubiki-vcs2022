using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg124
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt1 = new DateTime(2022, 4, 1);
            var dt2 = new DateTime(2022, 5, 2, 12, 34, 56);

            label3.Text = dt1.ToString();
            label4.Text = dt2.ToString();
        }
    }
}
