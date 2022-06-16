using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg149
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Dictionary<string, string> map = new Dictionary<string, string>()
        {
            {"JP","日本" },
            {"KR","韓国" },
            {"US","アメリカ" },
            {"GB","イギリス" },
            {"DE","ドイツ" },
            {"IT","イタリア" },
            {"FR", "フランス" },
            {"CN","中国" },
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            // リスト表示
            foreach ( var it in map )
            {
                listBox1.Items.Add($"{it.Key} : {it.Value}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var key = textBox1.Text;
            if ( map.ContainsKey(key) == true )
            {
                label3.Text = map[key];
            } else
            {
                label3.Text = "キーが見つかりませんでした";
            }
        }
    }
}
