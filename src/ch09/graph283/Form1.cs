using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph283
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 透過色を指定した場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 透過色を設定する
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorKey(Color.Red, Color.Red);
            // 画像を描画する
            var image = Properties.Resources.book;
            g.DrawImage(
                image,
                new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                ia);
        }

        /// <summary>
        /// 透過色を指定しない場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 透過色を指定しない
            var ia = new System.Drawing.Imaging.ImageAttributes();
            // 画像を描画する
            var image = Properties.Resources.book;
            g.DrawImage(
                image,
                new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                ia);

        }
    }
}
