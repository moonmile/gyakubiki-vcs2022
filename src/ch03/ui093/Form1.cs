using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui093
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new FontDialog()
            {
                ShowColor = true,
                Font = richTextBox1.SelectionFont ,
                Color = richTextBox1.SelectionColor,
            };
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                richTextBox1.SelectionFont = dlg.Font;
                richTextBox1.SelectionColor = dlg.Color;
            }
        }
    }
}
