using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file224
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if ( System.IO.Directory.Exists(path) == false )
            {
                MessageBox.Show("指定フォルダーが見つかりません");
                return;
            }
            listBox1.Items.Clear();
            var files = System.IO.Directory.GetFiles(path); 
            foreach ( var file in files)
            {
                listBox1.Items.Add(file);
            }
        }
    }
}
