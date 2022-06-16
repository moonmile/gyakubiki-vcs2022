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


namespace file220
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            if ( File.Exists(fname) == true )
            {
                label4.Text = File.GetCreationTime(fname).ToString();
                label5.Text = File.GetLastWriteTime(fname).ToString();
            }
            else if ( Directory.Exists(fname) == true )
            {
                label4.Text = Directory.GetCreationTime(fname).ToString();
                label5.Text = Directory.GetLastWriteTime(fname).ToString();
            }
            else
            {
                label4.Text = $"{fname} が見つかりませんでした";
                label5.Text = "";
            }
        }
    }
}
