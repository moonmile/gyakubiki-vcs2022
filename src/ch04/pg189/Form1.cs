using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg189
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task onWork(Label label)
        {
            var text = "";
            for (int i = 0; i < 10; i++)
            {
                text += "☺";
                this.Invoke(() => { label.Text = text; });
                // 500msecまでランダムに待つ
                await Task.Delay(Random.Shared.Next(500));
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            label11.Text = "開始 " + DateTime.Now.ToString();

            await Task.Run(() =>
            {
                var lst = new List<Task>();
                // 5つのタスクを同時実行する
                lst.Add(Task.Run(() => onWork(label1)));
                lst.Add(Task.Run(() => onWork(label2)));
                lst.Add(Task.Run(() => onWork(label3)));
                lst.Add(Task.Run(() => onWork(label4)));
                lst.Add(Task.Run(() => onWork(label5)));
                // すべてのタスクが終わるまで待つ
                Task.WaitAll(lst.ToArray());
            });
            label11.Text = "完了 " + DateTime.Now.ToString();
        }
    }
}
