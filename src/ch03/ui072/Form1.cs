using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui072
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoldToolStripMenuItem.Checked = !BoldToolStripMenuItem.Checked;
            if ( BoldToolStripMenuItem.Checked == true )
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            }
            else
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            }
        }
    }
}
