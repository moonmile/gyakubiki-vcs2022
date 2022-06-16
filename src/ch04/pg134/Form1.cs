using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg134
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            // チェック済みを調べる
            foreach ( CheckBox it in groupBox1.Controls )
            {
                if ( it.Checked == true )
                {
                    s += it.Text + ",";
                }
            }
            label1.Text = $"{s} を選択しました";
        }
    }
}
