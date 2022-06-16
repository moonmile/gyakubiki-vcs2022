using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file232
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
            using ( var sw = new System.IO.StreamWriter(path) )
            {
                sw.WriteLine("逆引き大全 C# 2022の極意");
                sw.WriteLine($"日付: {DateTime.Now}");
            }
            MessageBox.Show("ファイルを作成しました");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // シフトJISの場合は、プロバイダを登録する
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            string path = textBox1.Text;
            using (var sw = new StreamWriter(
                path,
                false,
                Encoding.GetEncoding("shift_jis")))
            {
                sw.WriteLine("逆引き大全 C# 2022の極意");
                sw.WriteLine($"日付: {DateTime.Now}");
                sw.WriteLine("シフトJISコードで保存されています");
            }
            MessageBox.Show("シフトJISでファイルを作成しました");

        }
    }
}
