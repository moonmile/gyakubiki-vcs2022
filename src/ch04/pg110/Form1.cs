using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg110
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? x ;

            // 入力により x に値を入れる
            if ( textBox1.Text == "" )
            {
                x = null;
            } 
            else
            {
                x = int.Parse(textBox1.Text);
            }

            // 結果を表示する
            if ( x.HasValue == false )
            {
                label2.Text = "x には値がありません(null)";
            } else
            {
                label2.Text = $"x = {x}";
            }
        }
    }
}
