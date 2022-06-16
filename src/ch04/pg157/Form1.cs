using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg157
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void calc( ref DateTime next, ref DateTime prev )
        {
            // 10年後と10年前を計算して参照で同時に返す
            next = next.AddYears(10);
            prev = prev.AddYears(-10);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // ref で渡す場合は、あらかじめ初期化しておく
            DateTime next = DateTime.Now;
            DateTime prev = DateTime.Now;
            calc(ref next, ref prev);
            label2.Text = $"10年後 : {next}";
            label3.Text = $"10年前 : {prev}";
        }




        class CalcDate
        {
            public DateTime Prev { get; set; }
            public DateTime Next { get; set; }
        }
        void calc2( CalcDate date )
        {
            date.Next = date.Next.AddYears(10);
            date.Prev = date.Prev.AddYears(-10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // クラスを利用してプロパティで返す
            CalcDate date = new CalcDate
            {
                Prev = DateTime.Now,
                Next = DateTime.Now,
            };
            calc2(date);
            label2.Text = $"10年後 : {date.Next}";
            label3.Text = $"10年前 : {date.Prev}";
        }
    }
}
