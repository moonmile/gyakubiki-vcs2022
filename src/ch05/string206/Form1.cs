using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string206
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            try
            {
                // 先頭の3文字だけ残す
                label3.Text = text.Remove(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // 範囲外の場合は例外が発生する
                MessageBox.Show(ex.Message);
            }
        }
    }
}
