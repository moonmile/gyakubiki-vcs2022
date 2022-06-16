using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace file226
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if ( File.Exists(path) == false )
            {
                return;
            }
            var attr = File.GetAttributes(path);
            checkBox1.Checked = (attr & FileAttributes.ReadOnly) != 0;
            checkBox2.Checked = (attr & FileAttributes.Hidden) != 0;
            checkBox3.Checked = (attr & FileAttributes.Compressed) != 0;
            checkBox4.Checked = (attr & FileAttributes.System) != 0;
        }
    }
}
