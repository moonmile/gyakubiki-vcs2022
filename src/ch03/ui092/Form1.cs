using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui092
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog()
            {
                Title = "保存先の画像ファイルの選択",
                Filter = "画像ファイル(*.jgp)|*.jpg|画像ファイル(*.png)|*.png",
            };
            if ( dlg.ShowDialog() == DialogResult.Cancel )
            {
                return;
            }
            if ( dlg.FilterIndex == 1 )
            {
                pictureBox1.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            } 
            else
            {
                pictureBox1.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            label1.Text = dlg.FileName;
            label2.Text = "保存しました";
        }
    }
}
