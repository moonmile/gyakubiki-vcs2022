using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg156
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 参照渡しで足し算と掛け算の答えを同時に返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ans1"></param>
        /// <param name="ans2"></param>
        private void calc( int x, int y, out int ans1, out int ans2 )
        {
            ans1 = x + y;
            ans2 = x * y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 20;
            int ans1, ans2;
            // 計算する
            calc( x, y, out ans1, out ans2 );
            label2.Text = $"ans1 = {ans1}";
            label3.Text = $"ans2 = {ans2}";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 20;
            var o = new Calc();
            // 計算する
            o.go(x, y);
            label2.Text = $"o.ans1 = {o.ans1}";
            label3.Text = $"o.ans2 = {o.ans2}";
        }
    }
    public class Calc
    {
        public int ans1 { get; private set;  }
        public int ans2 {  get; private  set; }
        public void go( int x, int y )
        {
            // 戻り値はプロパティで返す
            this.ans1 = x + y;
            this.ans2 = x * y;
        }
    }
}
