using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui043
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 透明度を指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            this.trackBar1.Value = 50;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.2;
            this.trackBar1.Value = 20;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value / 100.0;
        }
    }
}
