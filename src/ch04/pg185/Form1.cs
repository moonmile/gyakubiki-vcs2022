using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg185
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Task? _task;

        /// <summary>
        /// ラムダ式で処理関数を記述する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _task = new Task(async () =>
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
            });
            _task.Start();
        }


        /// <summary>
        /// メソッドで処理関数を記述する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _task = new Task(onWork);
            _task.Start();
        }
        async void onWork()
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
        }
    }
}
