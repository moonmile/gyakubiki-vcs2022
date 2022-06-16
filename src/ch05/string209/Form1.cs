using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string209
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            // 文字 char を指定して分割する
            string[] ary = text.Split(',');
            listBox1.Items.Clear();
            foreach ( var it in ary )
            {
                listBox1.Items.Add( it );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            // 文字列 string を指定して分割する
            string[] ary = text.Split(",");
            listBox1.Items.Clear();
            foreach (var it in ary)
            {
                listBox1.Items.Add(it);
            }
        }
    }
}
