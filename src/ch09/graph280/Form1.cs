using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph280
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
            // グラデーションを作成
            var br = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(0, 0), new(0, pictureBox1.Height),
                Color.Green, Color.White);
            g.FillRectangle(br, 0,0, this.pictureBox1.Width, this.pictureBox1.Height);
        }
    }
}
