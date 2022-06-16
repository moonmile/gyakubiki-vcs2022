using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file225
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            // フォルダー名を取得
            label6.Text = System.IO.Path.GetDirectoryName(path);
            // ファイル名を取得
            label7.Text = System.IO.Path.GetFileName(path);
            // 拡張子を取得
            label8.Text = System.IO.Path.GetExtension(path);
            // 拡張子を除いたファイル名を取得
            label9.Text = System.IO.Path.GetFileNameWithoutExtension(path);

        }
    }
}
