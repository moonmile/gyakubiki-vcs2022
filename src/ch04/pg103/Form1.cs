using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg103
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 100;
            long x = i;     // 暗黙の型変換

            double d = 123.456;
            label3.Text = d.ToString();
            int n = (int)d; // キャスト（桁落ちする）    
            label4.Text = n.ToString();

            object o = i;           // オブジェクト型にキャスト
            o = "Visual C# 2022";   // オブジェクト型の文字列を入れる

            string str1 = (string)o;    // 強制的に文字列にキャスト
            string? str2 = o as string; // 安全に型変換する
        }
    }
}
