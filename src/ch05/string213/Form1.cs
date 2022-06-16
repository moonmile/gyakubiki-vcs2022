using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string213
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            // 全角数字を半角数字に変換
            var replace = Regex.Replace(text, "[０-９]",
                new MatchEvaluator(t =>
                {
                    switch (t.Value)
                    {
                        case "０": return "0";
                        case "１": return "1";
                        case "２": return "2";
                        case "３": return "3";
                        case "４": return "4";
                        case "５": return "5";
                        case "６": return "6";
                        case "７": return "7";
                        case "８": return "8";
                        case "９": return "9";
                        default: return t.Value;
                    }
                }));

            // 長音やマイナスを削除
            label4.Text = Regex.Replace(replace, "[ーー-]", "");
        }
    }
}
