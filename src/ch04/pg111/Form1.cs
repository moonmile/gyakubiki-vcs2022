using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = ("masuda", 53, "Tokyo");
            
            label1.Text = a.ToString();
            label5.Text = a.Item1;
            label6.Text = a.Item2.ToString();
            label7.Text = a.Item3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = (name: "masuda", age: 53, address: "Tokyo");

            label1.Text = a.ToString();
            label5.Text = a.name;
            label6.Text = a.age.ToString();
            label7.Text = a.address;
        }
    }
}
