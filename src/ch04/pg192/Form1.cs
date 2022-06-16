using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg192
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            // 完了フラグ
            bool complete = false;
            // 進捗率
            int raito = 0;

            // プログレスバーを更新
            Task task = new Task(async () =>
            {
                while (complete == false)
                {
                    this.Invoke(() =>
                    {
                        label1.Text = $"進捗率：{raito} %";
                        progressBar1.Value = raito;

                    });
                    // 100msec 単位で画面を更新する
                    await Task.Delay(100);
                }
                this.Invoke(() =>
                {
                    label1.Text = $"進捗率：{raito} %";
                    progressBar1.Value = raito;
                });
            });
            task.Start();

            // 計算タスク
            int sum = await Task.Run<int>(async () =>
            {
                int sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    raito = i;
                    sum += i;
                    await Task.Delay(100);
                }
                raito = 100;
                complete = true;
                return sum;
            });

            label2.Text = $"合計値：{sum}";
        }
    }
}
