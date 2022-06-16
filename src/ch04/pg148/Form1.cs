using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg148
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string getCard()
        {
            var mark = new string[] { "♠", "♥", "♦", "♣" }[Random.Shared.Next(4)];
            var num = new string[] {
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            }[Random.Shared.Next(13)];
            return $"{mark}{num}";
        }

        List<string> cards = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                this.cards.Add(getCard());
            }
            listBox1.Items.AddRange(cards.ToArray());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // マーク順に編集する
            var items = new List<List<string>>();
            foreach (string mark in new string[] { "♠", "♥", "♦", "♣" })
            {
                var lst = cards.Where(t => t.StartsWith(mark)).ToList();
                items.Add(lst);
            }

            // 内容を確認する
            listBox2.Items.Clear();
            foreach (var it in items)
            {
                listBox2.Items.Add(string.Join(",", it));
            }
        }
    }
}
