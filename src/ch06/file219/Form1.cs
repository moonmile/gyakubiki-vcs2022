using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file219
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

            if ( System.IO.File.Exists(fname1) == false )
            {
                label4.Text = "コピー元のファイルがありません";
                return;
            }

            // 最初のコピー先を作成
            string fname2 =
                System.IO.Path.GetDirectoryName(fname1)+ "\\" +
                System.IO.Path.GetFileNameWithoutExtension(fname1)
                + " - コピー" +
                System.IO.Path.GetExtension(fname1);

            int n = 1;
            while (System.IO.File.Exists(fname2) == true)
            {
                n++;
                fname2 =
                    System.IO.Path.GetDirectoryName(fname1) + "\\" +
                    System.IO.Path.GetFileNameWithoutExtension(fname1)
                    + $" - コピー ({n})" +
                    System.IO.Path.GetExtension(fname1);
            }
            System.IO.File.Copy(fname1, fname2);
            label4.Text = $"{fname2} にコピーしました";
        }
    }
}
