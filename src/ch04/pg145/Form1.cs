using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg145
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
            // 先頭を削除する
            lst.RemoveAt(0);
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 項目を探しながら削除する
            var items = new List<string>();

            foreach ( var it in lst)
            {
                if ( it.StartsWith("♠"))
                {
                    items.Add(it);
                }
            }
            foreach ( var it in items)
            {
                lst.Remove(it);
            }
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }
}
