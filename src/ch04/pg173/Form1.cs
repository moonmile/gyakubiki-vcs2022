using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg173
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = new Sample
            {
                Name = "秀和太郎",
                Age = 30,
                Address = "東京都",
            };
            label3.Text = obj.Name;
            label4.Text = obj.ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var obj = new SubSample
            {
                Name = "秀和太郎",
                Age = 30,
                Address = "東京都",
            };
            label3.Text = obj.Name;
            label4.Text = obj.ShowData();
        }
    }

    /// <summary>
    /// 基本クラス
    /// </summary>
    public class Sample
    {
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Address { get; set; } = "";

        /// <summary>
        /// オーバーライド可能なメソッド
        /// </summary>
        /// <returns></returns>
        public virtual string ShowData()
        {
            return $"{Name} ({Age}) {Address}";
        }
    }
    
    /// <summary>
    /// 派生クラス
    /// </summary>
    public class SubSample : Sample
    {
        public override string ShowData()
        {
            return $"{Name}様 {Age}歳 住所（{Address})";
        }
    }
}
