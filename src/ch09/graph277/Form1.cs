using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph277
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
            // 四角形を表示
            for (int i = 0; i < 100; i++)
            {
                // ランダムに直線を描く
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                int width   = Random.Shared.Next(pictureBox1.Width/2);
                int height = Random.Shared.Next(pictureBox1.Height/2);
                g.DrawRectangle(Pens.Black, x, y, width, height);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            Brush[] burshs = new Brush[]
            {
                Brushes.Red,
                Brushes.Blue,
                Brushes.Yellow,
                Brushes.Green,
                Brushes.Pink,
            };
            // 塗りつぶした四角形
            for (int i = 0; i < 100; i++)
            {
                // ランダムに直線を描く
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                int width = Random.Shared.Next(pictureBox1.Width / 2);
                int height = Random.Shared.Next(pictureBox1.Height / 2);
                Brush brush = burshs[Random.Shared.Next(burshs.Length)];
                g.FillRectangle(brush, x, y, width, height);
            }

        }
    }
}
