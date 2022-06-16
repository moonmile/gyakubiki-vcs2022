using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg187
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await Task.Run<string>(async () =>
            {
                // 10秒後に停止する
                var end = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    this.Invoke(() =>
                    {
                        // 現在時刻を表示
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                    });
                    // 100msec待つ
                    await Task.Delay(100);
                }
                return DateTime.Now.ToString() + " に完了";
            });
            label2.Text = result;
        }
    }
}
