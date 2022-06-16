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

namespace file230
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
            if (File.Exists(path) == false)
            {
                MessageBox.Show("ファイルが見つかりません");
                return;
            }
            listBox1.Items.Clear();
            using (var sr = new StreamReader(path))
            {
                int n = 0;
                int ch = -1;
                while ((ch = sr.Read()) != -1)
                {
                    n++;
                    listBox1.Items.Add($"{n}: {(char)ch} {ch:X4}");
                }
            }

        }
    }
}
