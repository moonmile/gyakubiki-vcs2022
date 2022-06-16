using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph287
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
            var image1 = Properties.Resources.kazu;
            var image2 = Properties.Resources.frame;
            // 写真を描画する
            var rect = new Rectangle( 0,0,pictureBox1.Width, pictureBox1.Height );
            g.DrawImage(image1, rect, 0, 0, image1.Width, image1.Height, GraphicsUnit.Pixel);
            // 透明色を設定してフレームを描画する
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorKey(Color.Red, Color.Red);
            g.DrawImage(image2, rect, 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, ia);
        }
    }
}
