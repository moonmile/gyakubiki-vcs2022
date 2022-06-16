using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg107
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = @"c:\C#2022\Sample.txt";
            label5.Text = @"{ name: ""masuda"", country: ""Japan"" }";
            label6.Text = @"
このように改行を含めた
文章をコードに直接記述
することができます。
";
        }
    }
}
