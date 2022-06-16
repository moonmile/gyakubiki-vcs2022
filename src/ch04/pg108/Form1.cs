using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg108
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "ワイン";
            string s2 = "チーズ";

            label3.Text = $"{s1} と {s2}";
            label4.Text = $"{s1} の長さは {s1.Length} です";
        }
    }
}
