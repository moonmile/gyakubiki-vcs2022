using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui075
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;

        }
    }
}
