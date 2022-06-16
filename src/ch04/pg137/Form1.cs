using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg137
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 配列の宣言時に初期値を入れる
            var names = new string[]
            {
                "荒俣","夢野","沼","柄谷","谷崎",
            };
            // 以下の書き方も可能
             string[] names2 = { "荒俣", "夢野", "沼", "柄谷", "谷崎" };

            int index = comboBox1.SelectedIndex;
            if ( index == -1)
            {
                label2.Text = "クラスを選択してください";
                return;
            }
            label2.Text = $"{comboBox1.Text} 担任 {names[index]} 先生";
        }
    }
}
