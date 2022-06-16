using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg142
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<string> lst = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            // 項目を末尾に追加する
            lst.Add( DateTime.Now.ToString() );
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 項目をすべて削除
            lst.Clear();
            // 内容を表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }
}
