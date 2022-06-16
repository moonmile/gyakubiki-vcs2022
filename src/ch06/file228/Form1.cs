using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file228
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            if ( System.IO.File.Exists(fname) == false )
            {
                MessageBox.Show("ファイルが見つかりません");
                return;
            }
            using (var sr = new System.IO.StreamReader(fname))
            {
                MessageBox.Show("読み込み専用でファイルを開きました");
            }
            // あるいは以下のように Close メソッドを使う
            // var sr = new System.IO.StreamReader(fname);
            // sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            if (System.IO.File.Exists(fname) == false)
            {
                MessageBox.Show("ファイルが見つかりません");
                return;
            }
            using (var sw = new System.IO.StreamWriter(fname))
            {
                MessageBox.Show("書き出し専用でファイルを開きました");
            }
            // あるいは以下のように Close メソッドを使う
            // var sw = new System.IO.StreamWriter(fname);
            // sw.Close();

        }
    }
}
