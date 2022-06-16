using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui082
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
            if ( text != "" )
            {
                richTextBox1.SelectionStart += richTextBox1.SelectionLength;
                richTextBox1.SelectionLength = 0;
                richTextBox1.Focus();
                int pos = richTextBox1.Find(text, richTextBox1.SelectionStart, RichTextBoxFinds.None);
                if ( pos != -1 )
                {
                    // 検索にマッチした場所の色を変える
                    richTextBox1.SelectionBackColor = Color.Red;
                    richTextBox1.SelectionColor = Color.White;
                }
            }
        }
    }
}
