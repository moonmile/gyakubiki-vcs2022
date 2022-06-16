using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph289
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
            var image = Properties.Resources.book;
            // 画像を描画する
            g.DrawImage(image, 
                new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), 
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            // 文字を入れる
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            g.DrawString(text,
                new Font("Meiryo", 30.0f),
                Brushes.Red,
                new Point(0, 0));
        }
    }
}
