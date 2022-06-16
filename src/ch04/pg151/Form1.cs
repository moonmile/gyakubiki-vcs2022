using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg151
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, ValueTuple<string, string>> dic;


        private void Form1_Load(object sender, EventArgs e)
        {
            dic = new Dictionary<string, ValueTuple<string, string>>();
            dic.Add("JP", ("Japan", "日本"));
            dic.Add("CN", ("China", "中国"));
            dic.Add("KR", ("Republic of Korea", "韓国"));
            dic.Add("UK", ("United Kingdom","イギリス"));
            dic.Add("US", ("United States of America", "アメリカ"));
            dic.Add("CA", ("Canada", "カナダ"));
            // リストに表示
            foreach( var it in dic )
            {
                listBox1.Items.Add($"{it.Key}: {it.Value}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = textBox1.Text;
            if (dic.ContainsKey(key) == true)
            {
                var item = dic[key];
                label3.Text = $"{item.Item1} {item.Item2}";
            } else
            {
                label3.Text = "キーが見つかりません";
            }
        }
    }
}
