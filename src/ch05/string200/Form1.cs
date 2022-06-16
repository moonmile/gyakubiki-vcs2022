using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string200
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var target = textBox1.Text;
            var search = textBox2.Text;

            if ( target.Contains(search) == true )
            {
                label4.Text = "含まれています";
            }
            else
            {
                label4.Text = "含まれていません";
            }
        }
    }
}
