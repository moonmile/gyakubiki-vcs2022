using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui061
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(
                new string[] { "赤", "橙", "黄", "緑", "青", "藍", "紫" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (text != "")
            {
                listBox1.Items.Insert(0, text);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (text != "")
            {
                listBox1.Items.Add(text);
                textBox1.Clear();
            }
        }
    }
}
