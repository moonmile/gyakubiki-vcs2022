using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg144
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> lst = new List<string>();

        /// <summary>
        /// ひとつの要素を追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            var mark = new string[] { "♠", "♥", "♦", "♣" }[Random.Shared.Next(4)];
            var num = new string[] { 
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            }[Random.Shared.Next(13)];

            // ひとつの要素を追加する
            lst.Add($"{mark}{num}");
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }

        /// <summary>
        /// 複数の要素を追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var num = new string[] {
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            }[Random.Shared.Next(13)];

            // 複数の要素を一度に追加する
            lst.AddRange(
                new string[] {$"♠{num}",$"♥{num}",$"♦{num}",$"♣{num}" });
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());

        }
    }
}
