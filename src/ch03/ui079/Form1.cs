using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui079
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ファイル名", 200);
            listView1.Columns.Add("サイズ", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("更新日", 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if ( Directory.Exists(text) == false )
            {
                MessageBox.Show("指定したフォルダーが見つかりません");
                return;
            }
            var dirinfo = new DirectoryInfo(text);
            var files = dirinfo.GetFiles();
            listView1.Items.Clear();
            foreach (var it in files)
            {
                var item = new ListViewItem(it.Name);
                item.SubItems.Add(it.Length.ToString());
                item.SubItems.Add(it.LastWriteTime.ToString());
                listView1.Items.Add(item);
            }
        }
    }
}
