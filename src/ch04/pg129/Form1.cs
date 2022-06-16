using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg129
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
            switch( comboBox1.Text )
            {
                case "オレンジ":
                    label2.BackColor = Color.Orange;
                    break;
                case "ブルー":
                    label2.BackColor = Color.Blue;
                    break;
                case "イエロー":
                    label2.BackColor = Color.Yellow;
                    break;
                default:
                    label2.BackColor = Color.Empty;
                    break;  
            }
        }
    }
}
