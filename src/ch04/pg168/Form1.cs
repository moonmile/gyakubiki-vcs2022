using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg168
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = new Sample("秀和太郎");
            label3.Text = obj.ShowData();
            label4.Text = obj.GetAtena("御中");
        }
    }
    /// <summary>
    /// Sample クラス
    /// </summary>
    public class Sample
    {
        private string _id;
        private string _name;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Sample(string name)
        {
            _name = name;
            _id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 宛名を取得
        /// </summary>
        public string GetAtena(string post)
        {
            return $"{_name} {post}";
        }

        public string ShowData()
        {
            /// 先頭の８文字のみ表示する
            return _name + " " + _id.Substring(0, 8) + "...";
        }
    }
}
