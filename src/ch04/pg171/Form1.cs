using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg171
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // インスタンスの生成と同時にプロパティに値を設定
            var obj = new Sample
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都",
            };
            label4.Text = obj.Name;
            label5.Text = obj.Age.ToString();
            label6.Text = obj.Address;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // コンストラクタを使って初期化
            var obj = new Sample("マスダトモアキ", 53, "東京都");
            label4.Text = obj.Name;
            label5.Text = obj.Age.ToString();
            label6.Text = obj.Address;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // コンストラクタで変数名を指定する
            var obj = new Sample(
                name: "マスダトモアキ",
                age: 53,
                address: "東京都");
            label4.Text = obj.Name;
            label5.Text = obj.Age.ToString();
            label6.Text = obj.Address;
        }
    }

    /// <summary>
    /// Sampleクラス
    /// </summary>
    public class Sample
    {
        public string Name { get; set; } = "";
        public int Age {  get; set; }
        public string Address { get; set; } = "";

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Sample()
        {
        }
        /// <summary>
        /// 初期化付きコンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="address"></param>
        public Sample( string name, int age, string address )
        {
            this.Name = name; 
            this.Age = age; 
            this.Address = address ;
        }
    }

}
