using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg143
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = new List<string> {
                "東京", "神奈川", "埼玉", "千葉", "茨城", "栃木", "群馬"
            };

            label3.Text = lst.First(); // lst[0] でも良い
            label4.Text = lst.Count.ToString(); 
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }
}
