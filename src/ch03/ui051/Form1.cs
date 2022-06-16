using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui051
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ImeMode = ImeMode.Alpha;
            textBox2.ImeMode = ImeMode.On;

            /// フォーカスがあったときに強制的に半角モードにする
            textBox1.GotFocus += (_, __) =>
            {
                textBox1.ImeMode = ImeMode.Alpha;
            };
        }
    }
}
