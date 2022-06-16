using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui066
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach ( TabPage tab in tabControl1.TabPages)
            {
                foreach ( RadioButton btn in tab.Controls)
                {
                    if ( btn.Checked == true )
                    {
                        listBox1.Items.Add(btn.Text);
                    }
                }
            }
        }
    }
}
