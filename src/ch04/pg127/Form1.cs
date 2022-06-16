using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg127
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;

            label6.Text = dt.ToString();
            label7.Text = dt.ToShortDateString();
            label8.Text = dt.ToShortTimeString();
            label9.Text = dt.ToString("tt h時 m分 s秒");
            label10.Text = dt.ToString("yyyy年 M月 d日 dddd");
        }
    }
}
