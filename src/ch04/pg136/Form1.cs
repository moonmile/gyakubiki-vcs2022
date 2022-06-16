using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg136
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ary = new int[5];

            // 配列に数値を代入する
            int n = 1;
            for( int i=0; i<ary.Length; i++ )
            {
                ary[i] = n * n;
                n++;
            }
            // 配列の内容を表示する
            listBox1.Items.Clear();
            for (int i = 0; i < ary.Length; i++)
            {
                listBox1.Items.Add($"ary[{i}] = {ary[i]}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ary = new int[2,3];
            // 配列に数値を代入する
            int n = 1;
            for ( int i = 0; i < 2; i++ )
            {
                for ( int j = 0; j<3 ; j++ )
                {
                    ary[i, j] = n * n;
                    n++;
                }
            }
            // 配列の内容を表示する
            listBox1.Items.Clear();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    listBox1.Items.Add($"ary[{i},{j}] = {ary[i, j]}");
                }
            }
        }
    }
}
