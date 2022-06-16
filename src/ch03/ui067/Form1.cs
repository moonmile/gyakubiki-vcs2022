using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui067
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ファイルから表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("とうもろこし.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.にんじん;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

        }
    }
}
