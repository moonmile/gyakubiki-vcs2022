using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui077
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            Task.Factory.StartNew(async () =>
            {
                while ( progressBar1.Value < progressBar1.Maximum )
                {
                    this.Invoke(() =>
                   {
                       progressBar1.Value += 1;
                       label1.Text = $"{progressBar1.Value} % 経過";
                   });
                    await Task.Delay(100);

                }
            });
        }
    }
}
