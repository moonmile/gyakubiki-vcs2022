using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg183
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 引数で構造体を渡す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SampleStruct obj;
            obj.Name = "マスダトモアキ";
            obj.Age = 53;
            obj.Address = "東京都";
            label2.Text = ShowStruct(obj);
        }

        /// <summary>
        /// 引数でクラスを渡す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var obj = new SampleClass();
            obj.Name = "マスダトモアキ";
            obj.Age = 53;
            obj.Address = "東京都";
            label2.Text = ShowClass(obj);
        }

        /// <summary>
        /// 構造体を受け取る
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ShowStruct(SampleStruct obj)
        {
            return obj.ToString();
        }
        /// <summary>
        /// クラスを受け取る
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ShowClass(SampleClass obj)
        {
            // Nullable が不許可のため obj は null にならない
            return obj.ToString();
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
