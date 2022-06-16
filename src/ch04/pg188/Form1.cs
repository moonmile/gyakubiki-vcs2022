using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg188
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task onWork(Label label)
        {
            var end = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < end)
            {
                this.Invoke(() =>
                {
                    // 現在時刻を表示
                    label.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                });
                // 100msec待つ
                await Task.Delay(100);
            }
        }

        /// <summary>
        /// タスクを順次実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => onWork(label1));
            await Task.Run(() => onWork(label2));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => onWork(label1));
            Task.Run(() => onWork(label2));
        }
    }
}
