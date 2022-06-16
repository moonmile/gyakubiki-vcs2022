using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string199
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
                // 4文字目から3文字分取得
                textBox2.Text = text.Substring(4, 3);
            } 
            catch (ArgumentOutOfRangeException ex )
            {
                MessageBox.Show( ex.Message );
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            try
            {
                // 4文字目から6文字目（7文字の直前）まで取得
                textBox2.Text = text[4..7];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
