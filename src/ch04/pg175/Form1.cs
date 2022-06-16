using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg175
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Sample> list = new List<Sample>();

        private void button1_Click(object sender, EventArgs e)
        {
            // オブジェクトを生成して追加する
            var obj = new Sample() { Value = "新規生成" };
            list.Add(obj);
            // 内容を確認
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // カウンタをリセットして追加
            Sample.Reset();
            var obj = new Sample() { Value = "リセット" };
            list.Add(obj);
            // 内容を確認
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());

        }
    }

    public class Sample
    {
        private static int _uniqid = 0; // クラスに固有な値
        private int _id = 0;
        private string _value = "";     // オブジェクトのプロパティ
        private DateTime _created;      // 作成日

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sample()
        {
            ++_uniqid;
            _id = _uniqid;
            _created = DateTime.Now;
        }

        public int ID => _id;
        public string Value
        {
            get => _value;
            set => _value = value;
        }

        public override string ToString()
        {
            return $"{_id} : {_value} : {_created}";
        }

        /// <summary>
        /// IDをリセットする
        /// </summary>
        public static void Reset()
        {
            _uniqid = 0;
        }
    }
}
