using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui081
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if ( richTextBox1.SelectionFont != null )
            {
                // フォントサイズを変更
                var font = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(font.Name, 14);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null &&
                 richTextBox1.SelectionColor != Color.Empty)
            {
                // フォントの色を変更
                richTextBox1.SelectionColor =
                    richTextBox1.SelectionColor == Color.Black ? Color.Red : Color.Black;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                // フォントの太文字を変更
                var font = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(font.Name, font.Size,
                    font.Bold == true ? FontStyle.Regular : FontStyle.Bold);
            }

        }
    }
}
