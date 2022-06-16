using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file233
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
            using (var sw = new System.IO.StreamWriter(path,true))
            {
                sw.WriteLine($"書き込み日時: {DateTime.Now}");
            }
            MessageBox.Show("ファイルに追記しました");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ファイルを削除する
            string path = textBox1.Text;
            if ( System.IO.File.Exists(path) == true )
            {
                System.IO.File.Delete(path);
            }
            MessageBox.Show("ファイルを削除しました");
        }
    }
}
