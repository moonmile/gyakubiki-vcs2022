using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph284
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            var image = Properties.Resources.book;
            var mx = new System.Drawing.Drawing2D.Matrix();
            // 画像を中央で5度ずつ回転させる
            mx.Translate(-pictureBox1.Width/2, -pictureBox1.Height/2, System.Drawing.Drawing2D.MatrixOrder.Append);
            mx.RotateAt(n, new Point(0,0), System.Drawing.Drawing2D.MatrixOrder.Append);
            mx.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, System.Drawing.Drawing2D.MatrixOrder.Append);
            g.Transform = mx;
            g.DrawImage(image, new Point(0, 0));
            n += 5;
        }
    }
}
