using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file217
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fname = textBox1.Text;
            if ( System.IO.Directory.Exists(fname) == true )
            {
                System.IO.Directory.Delete(fname);
                label3.Text = $"フォルダー {fname} を削除しました";
            }
            else if (  System.IO.File.Exists(fname) == true )
            {
                System.IO.File.Delete(fname);
                label3.Text = $"ファイル {fname} を削除しました";
            }
            else
            {
                label3.Text = $"{fname} が見つかりませんでした";
            }
        }
    }
}
