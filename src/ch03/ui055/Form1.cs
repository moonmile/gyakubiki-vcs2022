using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui055
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            if ( checkBox1.Checked == true )
            {
                total += 1000;
            }
            if (checkBox2.Checked == true)
            {
                total += 500;
            }
            if (checkBox3.Checked == true)
            {
                total += 2000;
            }
            label1.Text = $"合計金額は {total:#,##0}円です";
        }
    }
}
