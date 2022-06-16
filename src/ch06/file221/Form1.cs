using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file221
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// カレントフォルダーを取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = System.IO.Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// カレントフォルダーを設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (path == string.Empty )
            {
                return;
            }
            System.IO.Directory.SetCurrentDirectory(path);
            MessageBox.Show($"カレントフォルダーを設定しました {path}");
        }
    }
}
