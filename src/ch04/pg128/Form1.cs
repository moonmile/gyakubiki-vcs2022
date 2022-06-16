using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg128
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            // 入力されているかどうかをチェック
            if ( textBox1.Text == "" )
            {
                label2.Text = "数値を入力してください";
                return;
            }
            // 数値かどうかをチェック
            if ( int.TryParse( textBox1.Text, out num ) == false )
            {
                label2.Text = "数字で入力してください";
                return;
            }
            // 範囲をチェック
            if ( num < 0 || num > 100 )
            {
                label2.Text = "範囲を正しく入力してください。";
                return;
            }
            // 入力した数値を表示する
            label2.Text = $"入力した数値は {num} です";
        }
    }
}
