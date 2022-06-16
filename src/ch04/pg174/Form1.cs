using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg174
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ModifiedValue<string> Data = new ModifiedValue<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            var names = new string[] { "増田智明", "ますだともあき", "マスダトモアキ" };
            Data.Value = names[Random.Shared.Next(names.Length)];
            label3.Text = $"{Data.Value} {Data.Modified.ToString()}";
        }

        private string Name1 = "マスダ" ;
        private string Name2 = "トモアキ";

        private void button2_Click(object sender, EventArgs e)
        {
            // 値を交換する
            Swap(ref Name1, ref Name2);
            label4.Text = $"{Name1} <=> {Name2}";
        }

        /// <summary>
        /// ジェネリックを使ったクラスの例
        /// 値を更新した時刻を保持する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ModifiedValue<T>
        {
            private T? _value;           // 型指定できるフィールド
            private DateTime _modified; // 更新日時

            public T? Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    _modified = DateTime.Now;
                }
            }
            public DateTime Modified => _modified;
        }
        /// <summary>
        /// ジェネリックを使った関数の例
        /// 値を交換する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap<T>( ref T a, ref T b )
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

}
