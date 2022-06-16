using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui063
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
                new string[] { "A4用紙", "A3用紙", "B5用紙", "B4用紙", "はがき", "レポート用紙" });
            listBox1.SelectionMode = SelectionMode.MultiSimple;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            foreach (string it in listBox1.SelectedItems)
            {
                listBox2.Items.Add(it);
                // 削除する項目を保存しておく
                items.Add(it);
            }
            foreach( string it in items)
            {
                listBox1.Items.Remove(it);
            }
        }
    }
}
