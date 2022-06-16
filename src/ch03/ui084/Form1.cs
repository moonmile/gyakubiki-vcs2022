using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui084
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 10;
            trackBar1.Maximum = 50;
            trackBar1.Value = 10;
            trackBar1.TickFrequency = 1;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 5;
            label1.Text = trackBar1.Value.ToString();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            var font = label2.Font;
            label2.Font = new Font(font.FontFamily, trackBar1.Value);
        }
    }
}
