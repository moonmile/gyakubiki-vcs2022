using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg161
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += (_, _) =>
            {
                label2.Text = "ラムダ式で実行しました";
            };
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            label2.Text = "イベントで実行しました";
        }
    }
}
