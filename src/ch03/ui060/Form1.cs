using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui060
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
                new string[] { "赤", "橙", "黄", "緑", "青", "藍","紫" });
        }

        /// <summary>
        /// リストを初期化する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(
                new string[] { "赤", "橙", "黄", "緑", "青", "藍", "紫" });

        }

        /// <summary>
        /// 先頭の項目を削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if ( listBox1.Items.Count > 0 )
            {
                listBox1.Items.RemoveAt(0);
            }
        }

        /// <summary>
        /// 末尾の項目を削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);
            }
        }
    }
}
