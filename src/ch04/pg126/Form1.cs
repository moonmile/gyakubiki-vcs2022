using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg126
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dt = DateTime.Now;

            label3.Text = $@"例:
  {dt.ToString("yyyy年MM月dd日")} 
  {dt.ToString("yyyy/MM/dd")} 
  {dt.ToString("yyyy-MM-dd")} 
";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParse(textBox1.Text, out dt) == false)
            {
                label2.Text = "日付が変換できませんでした";
            }
            else
            {

                label2.Text = dt.ToString();
            }
                    
        }

    }
}
