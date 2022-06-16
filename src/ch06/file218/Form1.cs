using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file218
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname1 = textBox1.Text;
            string fname2 = textBox2.Text;
            try
            {
                System.IO.Directory.Move(fname1, fname2);
                label4.Text = "フォルダーを移動しました";
            } 
            catch ( IOException ex )
            {
                // 移動先にフォルダーがある場合は、例外が発生する
                label4.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname1 = textBox1.Text;
            string fname2 = textBox2.Text;
            try
            {
                System.IO.File.Move(fname1, fname2);
                label4.Text = "ファイルを移動しました";
            }
            catch (IOException ex)
            {
                // 移動先にファイルがある場合は、例外が発生する
                label4.Text = ex.Message;
            }
        }
    }
}
