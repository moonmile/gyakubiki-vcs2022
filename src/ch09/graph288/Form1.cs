using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph288
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
            // 画像の大きさを変える
            var image = Properties.Resources.book;
            var mx = new System.Drawing.Drawing2D.Matrix();
            mx.Scale(2.0f, 2.0f);
            g.Transform = mx;
            g.DrawImage(image, new Point(0, 0));
        }
    }
}
