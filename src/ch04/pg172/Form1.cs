using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg172
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 基本クラスの利用
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
            // 派生クラスの利用
            var obj = new SubSample
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都",
                Telephone = "090-XXXX-XXXX"
            };
            label4.Text = obj.Name;
            label5.Text = obj.Age.ToString();
            label6.Text = obj.Address;
            label7.Text = obj.Telephone;

        }
    }


    /// <summary>
    /// Sampleクラス
    /// </summary>
    public class Sample
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
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
        public Sample(string name, int age, string address)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }
    }

    /// <summary>
    /// 派生クラス
    /// </summary>
    public class SubSample : Sample
    {
        public string Telephone { get; set; } = "";
        public SubSample()
        {

        }
        public  SubSample(
            string name,
            int age, 
            string address,
            string telephone ) : base( name, age, address)
        {
            Telephone = telephone;
        }
    }

}
