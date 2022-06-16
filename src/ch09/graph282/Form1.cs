using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph282
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
            var cm = new System.Drawing.Imaging.ColorMatrix()
            {
                Matrix00 = 0.393f,
                Matrix01 = 0.349f,
                Matrix02 = 0.272f,
                Matrix10 = 0.769f,
                Matrix11 = 0.686f,
                Matrix12 = 0.534f,
                Matrix20 = 0.189f,
                Matrix21 = 0.168f,
                Matrix22 = 0.131f,
                Matrix33 = 1f,
                Matrix44 = 1f,
            };
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorMatrix(cm);
            // 画像を描画する
            var image = Properties.Resources.kazu;
            g.DrawImage(
                image,
                new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                ia);

        }
    }
}
