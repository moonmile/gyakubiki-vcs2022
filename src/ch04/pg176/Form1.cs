using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg176
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,
            };

            var sum = lst.Sum();
            label4.Text = sum.ToString();
            var items = lst.Where(t => t % 3 == 0).ToList();
            label5.Text = items.Count.ToString();
            label6.Text = string.Join(",", items.Select(t => t.ToString()));
        }
    }
}
