using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg177
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var o = new Sample
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都",
            };
            // 通常のメソッド
            label4.Text = o.ShowData();
            // 拡張メソッド
            label5.Text = o.ToJson();

            var name = "マスダトモアキ";
            label6.Text = name.ToKanma();

        }
    }

    /// <summary>
    /// サンプルクラス
    /// </summary>
    public class Sample
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";

        public string ShowData()
        {
            return $"{Name} ({Age}) {Address}";
        }
    }
    /// サンプルクラスに拡張メソッドをつける
    public static class SampleEx
    {
        public static string ToJson(this Sample o)
        {
            return $@"{{ name: ""{o.Name}"", age: {o.Age}, addresss: ""{o.Address}""  }}";
        }
    }

    /// <summary>
    /// 文字列 string クラスを拡張する
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// 1文字ずつカンマで区切る
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToKanma(this string o)
        {
            return string.Join(",", o.ToArray());
        }
    }
}
