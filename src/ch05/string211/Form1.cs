using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string211
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // .NET 5/6 ではこれが必要
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var unicode = Encoding.Unicode.GetBytes(text);
            var sjis = Encoding.GetEncoding("shift_jis").GetBytes(text);
            var utf8 = Encoding.UTF8.GetBytes(text);

            label4.Text = BitConverter.ToString(unicode);
            label5.Text = BitConverter.ToString(sjis);
            label6.Text = BitConverter.ToString(utf8);


            foreach ( var en in Encoding.GetEncodings() )
            {
                System.Diagnostics.Debug.WriteLine(en.Name);
            }
        }
    }
}
