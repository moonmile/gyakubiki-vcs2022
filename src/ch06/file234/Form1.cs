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

namespace file234
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// バイナリデータを書き出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            // 出力する8バイトのデータ
            byte[] data = new byte[]
            {
                0x00, 0x00, 0x00, 0x00,
                0xFF, 0xFF, 0xFF, 0xFF,
            };

            using (var fs = File.OpenWrite(path))
            {
                using ( var bw  = new BinaryWriter(fs))
                {
                    bw.Write(data);
                }
            }
            MessageBox.Show("バイナリデータを書き込みました");
            
        }

        /// <summary>
        /// バイナリデータを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            using (var fs = File.OpenRead(path))
            {
                using (var br = new BinaryReader(fs))
                {
                    // ファイルの長さだけ読み込む
                    int count = (int)fs.Length;
                    byte [] data = br.ReadBytes(count);
                    MessageBox.Show("バイナリデータを読み込みました\n" +
                        BitConverter.ToString(data));
                }
            }
        }
    }
}
