using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg146
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> lst = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] marks = { "♠", "♥", "♦", "♣" };
            string[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            for (int i = 0; i < 13; i++)
            {
                var mark = marks[Random.Shared.Next(4)];
                var num = nums[Random.Shared.Next(13)];
                lst.Add($"{mark}{num}");
            }
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // リスト全体をコピーする
            var lst2 = this.lst.ToList();
            listBox2.Items.Clear();
            listBox2.Items.AddRange(lst2.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 部分的にコピーする
            var lst2 = this.lst.Where(t => t.StartsWith("♠")).ToList();
            listBox2.Items.Clear();
            listBox2.Items.AddRange(lst2.ToArray());
        }
    }
}
