using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // クラス内の定数
        const string APPLI = "Visual C# 2022 逆引き大全";
        const int TIPS = 500;

        private void button1_Click(object sender, EventArgs e)
        {
            // メソッド内の定数
            const string STR = "の極意";

            label1.Text = APPLI + " " + TIPS.ToString() + STR;
            label2.Text = $"{APPLI} {TIPS}{STR}";
        }
    }
}
