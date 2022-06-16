using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string210
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = new List<string>()
            {
                    "東京都",
                    "北海道",
                    "大阪府",
                    "福岡県",
            };
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
            // 連結する
            label3.Text = string.Join("★", lst);
        }
    }
}
