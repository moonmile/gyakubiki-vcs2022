using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph290
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(Properties.Resources.book);
            var g = Graphics.FromImage(image);
            // 文字を入れる
            string text = DateTime.Now.ToString("HH:mm");
            g.DrawString(text,
                new Font("Meiryo", 30.0f),
                Brushes.Red,
                new Point(0, 0));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(pictureBox1.Image);
            image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                $"\\{DateTime.Now.ToString("yyyy-MM-dd")}.png",
                System.Drawing.Imaging.ImageFormat.Png );
            MessageBox.Show("画像を保存しました");
        }
    }
}
