using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg159
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string checkTest( bool result, params string[] kamoku )
        {
            if ( result == true )
            {
                return "合格";
            }
            else
            {
                var gouhi = "追試 -> ";
                foreach ( var it in kamoku )
                {
                    gouhi += $"{it} ,";
                }
                return gouhi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 最初の引数のみ指定
            label4.Text = checkTest(true);
            // ２番目の引数を指定
            label5.Text = checkTest(false, "国語");
            // ２番目の引数を３つ指定
            label6.Text = checkTest(false, "国語","数学","情報");
        }
    }
}
