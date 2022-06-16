using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg184
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SampleStruct obj = makeStruct("マスダトモアキ", 53, "東京都");
            label2.Text = obj.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SampleClass obj = makeClass("マスダトモアキ", 53, "東京都");
            label2.Text = obj.ToString();
        }

        /// <summary>
        /// 構造体を返す関数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        SampleStruct makeStruct( string name, int age, string address )
        {
            SampleStruct obj;
            obj.Name = name;
            obj.Age = age;
            obj.Address = address;
            return obj;
        }
        SampleClass makeClass(string name, int age, string address)
        {
            var obj = new SampleClass();
            obj.Name = name;
            obj.Age = age;
            obj.Address = address;
            return obj;
        }
    }

    /// <summary>
    /// 構造体の定義
    /// </summary>
    public struct SampleStruct
    {
        public string Name;
        public int Age;
        public string Address;

        public override string ToString()
        {
            return $"構造体：{Name} ({Age}) in {Address}";
        }
    }
    /// <summary>
    /// クラスの定義
    /// </summary>
    public struct SampleClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"クラス：{Name} ({Age}) in {Address}";
        }
    }

}
