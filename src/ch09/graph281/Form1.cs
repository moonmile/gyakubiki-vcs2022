using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph281
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            // 市松模様で塗る
            g.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.FillRectangle(Brushes.Black,
                pictureBox1.Width / 2, pictureBox1.Height / 2,
                pictureBox1.Width / 2, pictureBox1.Height / 2);
            // 透明度を指定する
            var cm = new System.Drawing.Imaging.ColorMatrix()
            {
                Matrix00 = 1f, // 赤
                Matrix11 = 1f, // 緑
                Matrix22 = 1f, // 青
                Matrix33 = 0.5f, // 透明度（アルファチャンネル）
                Matrix44 = 1f,
            };
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorMatrix(cm);
            var image = Properties.Resources.book;
            // 画像を半透明にして貼る
            g.DrawImage(
                image,
                new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                ia);
        }
    }
}
