using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( MaximizeBox & MinimizeBox )
            {
                MaximizeBox = false;
                MinimizeBox = false;
            } else {
                MaximizeBox = true;
                MinimizeBox = true;
            }
        }
    }
}
