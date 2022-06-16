using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph278
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
            for (int i = 0; i < 100; i++)
            {
                // ランダムに円を描く
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                int r = Random.Shared.Next(140) + 10;
                g.DrawEllipse(Pens.Black, x, y, r, r);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            Brush[] burshs = new Brush[]
            {
                Brushes.Red,
                Brushes.Blue,
                Brushes.Yellow,
                Brushes.Green,
                Brushes.Pink,
            };
            g.Clear(DefaultBackColor);
            for (int i = 0; i < 100; i++)
            {
                // ランダムに円を描く
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                int r = Random.Shared.Next(140) + 10;
                Brush brush = burshs[Random.Shared.Next(burshs.Length)];
                g.FillEllipse(brush, x, y, r, r);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            var brush = new TextureBrush(Properties.Resources.book);
            g.Clear(DefaultBackColor);
            for (int i = 0; i < 10; i++)
            {
                // ランダムに円を描く
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                int r = 200;
                g.FillEllipse(brush, x, y, r, r);
            }
        }
    }
}
