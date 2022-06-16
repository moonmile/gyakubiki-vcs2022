using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg135
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "";
            string s2 = "";
            // チェック済みを調べる
            foreach (CheckBox it in groupBox1.Controls)
            {
                if (it.Checked == true)
                {
                    s1 += it.Text + ",";
                    continue;
                }
                // 残りの項目
                s2 += it.Text + ",";
            }
            label1.Text = $"{s1} を選択しました";
            label2.Text = $"{s2} が未選択でした";
        }
    }
}
