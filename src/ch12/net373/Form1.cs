using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace net373
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PINGを送信する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            var ping = new Ping();
            string host = textBox1.Text;
            listBox1.Items.Clear();
            // 1秒おきに4回送信する
            for ( int i=0; i<4; i++ )
            {
                var reply = await ping.SendPingAsync(host, 2000);
                listBox1.Items.Add($"ip: {reply.Address} {reply.Status} time: {reply.RoundtripTime} ms");
                await Task.Delay(1000);
            }
        }
    }
}
