using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg186
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 指定したタスクを即実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                var end = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    this.Invoke(() =>
                   {
                       label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                   });
                    await Task.Delay(100);
                }
            });
        }

        /// <summary>
        /// 作成後5秒間待ってから実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            var task = new Task(async () =>
            {
                var end = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    this.Invoke(() =>
                    {
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                    });
                    await Task.Delay(100);
                }
            });
            await Task.Delay(5000);
            task.Start();
        }
    }
}
