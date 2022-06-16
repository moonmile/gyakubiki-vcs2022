using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg164
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 内部定義した関数
            int add( int x, int y)
            {
                return x + y;

            }
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int ans = add(a, b);
            label4.Text = ans.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var add = (int x, int y) => x + y;
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int ans = add(a, b);
            label4.Text = ans.ToString();
        }
    }
}
