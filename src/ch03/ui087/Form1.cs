using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui087
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void DockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockToolStripMenuItem.Checked = !DockToolStripMenuItem.Checked;
            if (DockToolStripMenuItem.Checked == true )
            {
                pictureBox1.Dock = DockStyle.Fill;
            } 
            else
            {
                pictureBox1.Dock = DockStyle.None;
            }

        }
    }
}
