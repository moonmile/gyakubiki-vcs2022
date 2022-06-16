using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui091
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Title = "画像ファイルの選択",
                CheckFileExists = true,
                RestoreDirectory = true,
                Filter = "イメージファイル|*.bmp;*.jpg;*.png;"
            };
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                label1.Text = dlg.FileName;
                label2.Text = dlg.SafeFileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            } else
            {
                label1.Text = "";
                label2.Text = "";
                pictureBox1.Image = null;
            }
        }
    }
}
