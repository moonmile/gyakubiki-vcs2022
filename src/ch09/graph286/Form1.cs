using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph286
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int page = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            var image = Properties.Resources.cocks;
            // ページを進める
            page++;
            if  ( page >= 5 )
            {
                page = 0;
            }
            var pt = new Point(0, page * 600);
            g.DrawImage(image, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                new RectangleF(0, page * 600, 800, 600), GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 連続したビットマップを作成
        /// </summary>
        void makeBitmap()
        {
            var bmp = new Bitmap(Properties.Resources.cock001, 800, 600 * 5);
            var g = Graphics.FromImage(bmp);
            int width = Properties.Resources.cock001.Width;
            int height = Properties.Resources.cock001.Height;
            g.DrawImage(Properties.Resources.cock001, new Rectangle(0, 600 * 0, 800, 600), 0, 0, width, height, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.cock002, new Rectangle(0, 600 * 1, 800, 600), 0, 0, width, height, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.cock003, new Rectangle(0, 600 * 2, 800, 600), 0, 0, width, height, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.cock004, new Rectangle(0, 600 * 3, 800, 600), 0, 0, width, height, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.cock005, new Rectangle(0, 600 * 4, 800, 600), 0, 0, width, height, GraphicsUnit.Pixel);
            bmp.Save(@"cocks.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

    }
}
