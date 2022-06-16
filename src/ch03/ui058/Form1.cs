using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui058
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期値を設定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton6.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text1 = "";
            var text2 = "";
            foreach ( RadioButton btn in groupBox1.Controls )
            {
                if  ( btn.Checked == true )
                {
                    text1 = btn.Text;
                    break;
                }
            }
            foreach (RadioButton btn in groupBox2.Controls)
            {
                if (btn.Checked == true)
                {
                    text2 = btn.Text;
                    break;
                }
            }
            label2.Text = $"年代:{text1}  性別:{text2}";

        }

    }
}
