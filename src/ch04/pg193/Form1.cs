using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg193
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    this.Invoke(() =>
                    {
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                    });
                    System.Threading.Thread.Sleep(100);
                }
            });
            label1.Text = "完了";

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(async () => {
                for (int i = 0; i < 100; i++)
                {
                    this.Invoke(() =>
                    {
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                    });
                    await Task.Delay(100);
                }
            });
            label1.Text = "完了";
        }
    }
}
