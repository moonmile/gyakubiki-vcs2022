using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg195
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Threading.CancellationTokenSource? cts;

        private async void button1_Click(object sender, EventArgs e)
        {
            cts = new System.Threading.CancellationTokenSource();

            bool result = await Task.Run<bool>(async () =>
           {
               var end = DateTime.Now.AddSeconds(10);
               while ( DateTime.Now < end )
               {
                   // キャンセルされていれば、途中でループを終える
                   if ( cts.Token.IsCancellationRequested )
                   {
                       return false;
                   }
                   this.Invoke(() => {
                       label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                   });
                   await Task.Delay(100);
               }
               return true;
           }, cts.Token );

            label1.Text = $"タスク結果: {result}";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // タスクをキャンセルする
            if ( cts != null )
            {
                cts.Cancel();
            }
        }
    }
}
