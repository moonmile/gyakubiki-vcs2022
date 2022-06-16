using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net372
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hostname = System.Net.Dns.GetHostName();
            // IPアドレスを取得
            var addrs = System.Net.Dns.GetHostAddresses(hostname);
            listBox1.Items.Clear();
            foreach (var ip in addrs)
            {
                // iPv4 のみ追加
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    listBox1.Items.Add(ip.ToString());
                }
            }
        }
    }
}
