using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string203
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
            var oldText = textBox3.Text;     // 置き換え対象
            var newText = textBox4.Text;    // 置き換える文字列

            textBox2.Text = text.Replace( oldText, newText );
        }
    }
}
