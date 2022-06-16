using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui065
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { 
                "檸檬 🍋","葡萄 🍇", "林檎 🍎", "メロン 🍈"
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( comboBox1.SelectedIndex ==-1 )
            {
                label1.Text = "項目が選択されていません";
            } 
            else 
            {
                label1.Text = comboBox1.SelectedItem as string;

            }
        }
    }
}
