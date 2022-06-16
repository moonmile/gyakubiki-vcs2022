using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg140
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 配列内をすべてクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string[] ary = { "東京", "神奈川", "埼玉", "千葉", "栃木", "群馬", "茨城" };

            listBox1.Items.AddRange(ary);
            // すべてクリアする
            Array.Clear(ary);
            foreach ( var it in ary )
            {
                listBox2.Items.Add(it ?? "(null)");
            }
        }

        /// <summary>
        /// 配列内を部分的にクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string[] ary = { "東京", "神奈川", "埼玉", "千葉", "栃木", "群馬", "茨城" };

            listBox1.Items.AddRange(ary);
            // 2番目と3番目をクリアする
            Array.Clear(ary,2,2);
            foreach (var it in ary)
            {
                listBox2.Items.Add(it ?? "(null)");
            }
        }
    }
}
