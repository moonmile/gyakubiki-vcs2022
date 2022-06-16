using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg109
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = @"{ name: ""増田智明"", age: 53 }";

            var o = JsonConvert.DeserializeObject<dynamic>(json);
            // name や age は実行時に解決される
            label3.Text = o.name;
            label4.Text = o.age.ToString(); 

        }
    }
}
