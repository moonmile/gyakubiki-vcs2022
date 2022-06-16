using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg138
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var ary1 = new int[100];
            var ary2 = new int[10, 20];

            label1.Text = $"ary1 の要素数は {ary1.Length}";
            var text = $"ary2 の要素数は {ary2.Length} \n" 
                + $"1つめの次元の要素数は {ary2.GetLength(0)}\n"
                + $"2つめの次元の要素数は {ary2.GetLength(1)}\n";
            label2.Text = text;
        }
    }
}
