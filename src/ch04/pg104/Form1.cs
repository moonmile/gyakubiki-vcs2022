using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg104
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            double ans = x + y;
            textBox3.Text = ans.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = 0.0;
            double y = 0.0;
            // 安全に文字列から数値へ変換する
            if (double.TryParse(textBox1.Text, out x) == false)
            {
                return;
            }
            if (double.TryParse(textBox2.Text, out y) == false)
            {
                return;
            }
            double ans = x + y;
            textBox3.Text = ans.ToString();
        }
    }
}
