using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui056
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = "";
            if ( radioButton1.Checked == true )
            {
                text = "商品A";
            }
            if (radioButton2.Checked == true)
            {
                text = "商品B";
            }
            if (radioButton3.Checked == true)
            {
                text = "商品C";
            }
            label1.Text = $"{text} が選択されました";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            label1.Text = "";
        }
    }
}
