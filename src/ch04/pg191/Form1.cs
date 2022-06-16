﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg191
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<int> onWork()
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum += i;
                this.Invoke(() => {
                    label1.Text = DateTime.Now.ToString("HH:MM:ss.fff");
                });
                await Task.Delay(100);
            }
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run<int>(onWork)
                .ContinueWith(t =>
                {
                    // 結果を表示
                    int sum = t.Result;
                    this.Invoke(() =>
                    {
                        label2.Text = $"合計値：{sum}";
                    });
                });
        }
    }
}
