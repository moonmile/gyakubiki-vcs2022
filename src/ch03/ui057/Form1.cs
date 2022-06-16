using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui057
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = "";
            foreach ( RadioButton btn in panel1.Controls)
            {
                if ( btn.Checked == true )
                {
                    text = btn.Text;
                }
            }
            label2.Text = $"{text} を選択しました";
        }
    }
}
