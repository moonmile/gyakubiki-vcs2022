using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string204
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<string>();
            list.Add("東京都");
            list.Add("埼玉県");
            list.Add("神奈川県");
            list.Add("千葉県");
            list.Add("茨城県");
            list.Add("栃木県");
            list.Add("群馬県");
        }

        List<string> list = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach ( var it in  list)
            {
                listBox1.Items.Add(it);
                // 末尾が「県」であれば追加する
                if (it.EndsWith("県"))
                {
                    listBox2.Items.Add(it);
                }
            }
        }
    }
}
