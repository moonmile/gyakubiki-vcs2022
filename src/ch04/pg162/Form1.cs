using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg162
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "";
            var lst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // ラムダ式で連結する
            lst.ForEach(x => text += $"{x * x},");
            label2.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            var lst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // foreach で連結する
            foreach ( var it in lst )
            {
                text += $"{it * it},";
            }
            label2.Text = text;
        }
    }
}
