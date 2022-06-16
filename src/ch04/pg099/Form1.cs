using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg099
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 整数リテラルの記述例
            var x1 = 100;       // int 型
            var x2 = 100u;      // uint 型
            var x3 = 100L;      // long 型
            var x4 = 100ul;     // ulong 型
            // 実数リテラルの記述例
            var y1 = 100f;      // float 型
            var y2 = 100d;      // double 型
            var y3 = 100m;      // decimal 型
        }
    }
}
