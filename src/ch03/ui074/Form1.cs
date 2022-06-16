using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui074
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tb = contextMenuStrip1.SourceControl as TextBox;
            if ( tb != null )
            {
                tb.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tb = contextMenuStrip1.SourceControl as TextBox;
            if (tb != null)
            {
                tb.TextAlign = HorizontalAlignment.Center;
            }

        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tb = contextMenuStrip1.SourceControl as TextBox;
            if (tb != null)
            {
                tb.TextAlign = HorizontalAlignment.Right;
            }

        }
    }
}
