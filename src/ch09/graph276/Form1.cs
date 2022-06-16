using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph276
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
            g.Clear(DefaultBackColor);
            // 普通の直線
            for ( int i=0; i<100; i++ )
            {
                // ランダムに直線を描く
                int x1 = Random.Shared.Next(pictureBox1.Width);
                int y1 = Random.Shared.Next(pictureBox1.Height);
                int x2 = Random.Shared.Next(pictureBox1.Width);
                int y2 = Random.Shared.Next(pictureBox1.Height);
                g.DrawLine(Pens.Black, x1, y1, x2, y2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 太い線で描画
            var pen = new Pen(Color.Red, 5);
            for (int i = 0; i < 100; i++)
            {
                // ランダムに直線を描く
                int x1 = Random.Shared.Next(pictureBox1.Width);
                int y1 = Random.Shared.Next(pictureBox1.Height);
                int x2 = Random.Shared.Next(pictureBox1.Width);
                int y2 = Random.Shared.Next(pictureBox1.Height);
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 点線で描画
            var pen = new Pen(Color.Blue)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            for (int i = 0; i < 100; i++)
            {
                // ランダムに直線を描く
                int x1 = Random.Shared.Next(pictureBox1.Width);
                int y1 = Random.Shared.Next(pictureBox1.Height);
                int x2 = Random.Shared.Next(pictureBox1.Width);
                int y2 = Random.Shared.Next(pictureBox1.Height);
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
}
