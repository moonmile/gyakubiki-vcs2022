using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui064
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.AddRange(new string[] { "テニス", "バドミントン", "陸上", "柔道", "水泳" });
        }
        /// <summary>
        /// チェックした項目をリストへ追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach ( var it in checkedListBox1.CheckedItems )
            {
                listBox1.Items.Add(it);
            }
        }

    }
}
