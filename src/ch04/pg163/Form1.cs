using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg163
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ラムダ式の初期値
        /// </summary>
        Func<int, int, int> _func = (x, y) => 0;

        /// <summary>
        /// ラムダ式を設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButton1.Checked )
            {
                _func = (x, y) => x + y;
            }
            if ( radioButton2.Checked )
            {
                _func = (x, y) => x * y;
            }
            if ( radioButton3.Checked )
            {
                _func = (x, y) => (int)Math.Pow(x, y);
            }

        }

        /// <summary>
        /// ラムダ式を実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            int ans = _func(x, y);
            label4.Text = ans.ToString();
        }
    }
}
