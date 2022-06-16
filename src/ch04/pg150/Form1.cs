using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg150
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<int,string> map = new Dictionary<int,string>();

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            // キーと値を追加
            map.Add(id, name);
            // 以下でも良い
            // map[id] = name;

            // 内容を確認する
            listBox1.Items.Clear();
            foreach ( var it in map )
            {
                listBox1.Items.Add($"{it.Key} : {it.Value}");
            }

        }
    }
}
