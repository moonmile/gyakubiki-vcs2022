using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg141
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ary1 = { "東京", "神奈川", "埼玉", "千葉", "茨城", "栃木", "群馬" };

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            listBox1.Items.AddRange(ary1);
            // CopyToを使う
            var ary2 = new string[ary1.Length];
            ary1.CopyTo(ary2, 0);
            // Cloneを使う
            var ary3 = (string[])ary1.Clone();

            listBox1.Items.AddRange(ary1);
            listBox2.Items.AddRange(ary2);
            listBox3.Items.AddRange(ary3);
        }
    }
}
