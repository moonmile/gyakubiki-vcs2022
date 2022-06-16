using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui053
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
            if (text.Length < 4 )
            {
                label2.Text = "4文字以上入力してください";
            }
            else
            {
                label2.Text = $"{text.Length}文字入力されました";
            }
        }
    }
}
