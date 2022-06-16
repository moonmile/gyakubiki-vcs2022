using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg139
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var items = new string[]
            {
                "PowerPoint","Word","Excel","Access",
            };

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // ソート前
            listBox1.Items.AddRange(items);
            // 昇順でソート
            Array.Sort(items);
            listBox2.Items.AddRange(items);
            // 降順でソート
            Array.Reverse(items);
            listBox3.Items.AddRange(items);
        }
    }
}
