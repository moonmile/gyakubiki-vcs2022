using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui039
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ヘルプボタンで解説の必要な場所をクリックしたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (RectangleToScreen(this.button1.Bounds).Contains( hlpevent.MousePos) == true )
            {
                MessageBox.Show("これは一番上のボタンです");
            }
            if (RectangleToScreen(this.button2.Bounds).Contains(hlpevent.MousePos) == true)
            {
                MessageBox.Show("これは真ん中のボタンです");
            }
            if (RectangleToScreen(this.button3.Bounds).Contains(hlpevent.MousePos) == true)
            {
                MessageBox.Show("これは一番下のボタンです");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
