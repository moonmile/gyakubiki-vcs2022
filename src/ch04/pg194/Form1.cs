using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg194
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Threading.ManualResetEvent? mre;

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                mre = new ManualResetEvent(false);
                // 終了時刻
                var end = DateTime.Now.AddSeconds(20);
                // 一時停止する時刻
                var stop = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    if (DateTime.Now > stop)
                    {
                        // 10秒後にイベント待ちになる
                        this.Invoke(() =>
                        {
                            label1.Text = "解除イベント待ち";
                        });
                        mre.Reset();
                        // イベント待ち
                        mre.WaitOne();
                        // 一時停止をやめる
                        stop = end;
                    }
                    this.Invoke(() =>
                    {
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                    });
                    await Task.Delay(100);
                }
            });
            label1.Text = "タスク終了 " + DateTime.Now.ToString("HH:MM:ss.fff");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mre != null)
            {
                // イベント待ちを解除
                mre.Set();
            }
        }
    }
}
