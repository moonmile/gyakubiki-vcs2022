using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string201
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

            listBox1.Items.Clear();
            int pos = -1;
            while ( true )
            {
                pos = target.IndexOf(search, pos + 1);
                if ( pos == -1 )
                {
                    break;
                }
                listBox1.Items.Add($"{pos + 1}文字目");
            }
        }
    }
}
