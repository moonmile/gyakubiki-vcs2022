using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui062
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(
                new string[] { "赤", "橙", "黄", "緑", "青", "藍", "紫" });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            if ( index == -1)
            {
                label1.Text = "未選択";
            }
            else
            {
                var text = listBox1.SelectedItem.ToString();
                label1.Text = $"{index}番目の {text} を選択";
            }
            // SelectedItem プロパティでも良い
            // if ( listBox1.SelectedItem != null ) { ...


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            label1.Text = "";
        }
    }
}
