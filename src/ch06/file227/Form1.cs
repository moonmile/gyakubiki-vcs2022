using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file227
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ドキュメント
            label5.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // デスクトップ
            label6.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // ピクチャ
            label7.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // ビデオ
            label8.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            // アプリケーションデータ
            label9.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
    }
}
