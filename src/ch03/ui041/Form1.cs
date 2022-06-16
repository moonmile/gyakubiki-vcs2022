using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui041
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 位置を指定して開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2()
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0)
            };
            form.ShowDialog();
        }

        /// <summary>
        /// 画面の中央に開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form2()
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            form.ShowDialog();
        }

        /// <summary>
        /// 既定の位置で開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.ShowDialog();
        }

        /// <summary>
        /// 既定の位置で開く。境界線を持つ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var form = new Form2() {
                StartPosition = FormStartPosition.WindowsDefaultBounds,
            };
            form.ShowDialog();
        }

        /// <summary>
        /// 親画面の中央で開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            var form = new Form2()
            {
                StartPosition = FormStartPosition.CenterParent,
            };
            form.ShowDialog();
        }
    }
}
