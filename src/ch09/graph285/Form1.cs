using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph285
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
            // 画像を反転する
            var image = Properties.Resources.book;
            g.DrawImage(image, pictureBox1.Width , 0, -pictureBox1.Width, pictureBox1.Height);
        }
    }
}
