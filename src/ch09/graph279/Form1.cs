using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph279
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
            // 折れ線を描画
            List<Point> points = new List<Point>();
            for (int i = 0; i < 20; i++)
            {
                int x = pictureBox1.Width / 20 * i;
                int y = Random.Shared.Next(pictureBox1.Height);
                points.Add(new Point(x, y));
            }
            g.DrawLines(Pens.Black, points.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 閉じた多角形を描画
            List<Point> points = new List<Point>();
            for (int i = 0; i < 20; i++)
            {
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                points.Add(new Point(x, y));
            }
            g.DrawPolygon(Pens.Red, points.ToArray());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(DefaultBackColor);
            // 塗りつぶした多角形を描画
            List<Point> points = new List<Point>();
            for (int i = 0; i < 20; i++)
            {
                int x = Random.Shared.Next(pictureBox1.Width);
                int y = Random.Shared.Next(pictureBox1.Height);
                points.Add(new Point(x, y));
            }
            g.FillPolygon(Brushes.Green, points.ToArray());
        }
    }
}
