using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg102
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 列挙型を定義する
        /// </summary>
        enum Rank   // データ型を省略しているので int 型になる
        {
            Special ,   // 0
            Standard,   // 1
            Basic,      // 2
        }

        Rank checkRank( int n )
        {
            if (n >= 80) return Rank.Special;
            if (n >= 60 ) return Rank.Standard;
            return Rank.Basic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            var result = checkRank(n);
            label3.Text = result.ToString();
            label4.Text = ((int)result).ToString();
        }
    }
}
