using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg147
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        List<string> slst1 = new List<string> {
                "東京", "神奈川", "埼玉", "千葉", "茨城", "栃木", "群馬"
            };
        List<string> slst2 = new List<string> ();

        List<Prefecture> olst1 = new List<Prefecture>
        {
            new Prefecture { Code = "13", Name = "東京"},
            new Prefecture { Code = "14", Name = "神奈川"},
            new Prefecture { Code = "11", Name = "埼玉"},
            new Prefecture { Code = "12", Name = "千葉"},
            new Prefecture { Code = "08", Name = "茨城"},
            new Prefecture { Code = "09", Name = "栃木"},
            new Prefecture { Code = "10", Name = "群馬"},
        };
        List<Prefecture> olst2 = new List<Prefecture>();


        /// <summary>
        /// 文字列を扱う場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(slst1.ToArray());
            this.slst2 = slst1.ToList();
            listBox2.Items.AddRange(slst2.ToArray());
        }
        /// <summary>
        /// コピー元の値を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // コピー元の要素を変更する
            var index = slst1.FindIndex(t => t == "東京");
            slst1[index] = "TOKYO";
            // 内容を確認する
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(slst1.ToArray());
            listBox2.Items.AddRange(slst2.ToArray());
            // 新しいリストの場合は文字列がコピーされるので
            // コピー先は変更されない
        }

        /// <summary>
        /// クラス（オブジェクト）を扱う場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(olst1.ToArray());
            this.olst2 = olst1.ToList();
            listBox2.Items.AddRange(olst2.ToArray());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // コピー元の要素を変更する
            var index = olst1.FindIndex(t => t.Name == "東京");
            olst1[index].Name = "TOKYO";
            // 内容を確認する
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(olst1.ToArray());
            listBox2.Items.AddRange(olst2.ToArray());
            // 要素となるオブジェクトを共有しているので、
            // Nameプロパティの値が変わる
        }
    }


    public class Prefecture
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public override string ToString()
        {
            return $"{Code}: {Name}";
        }
    }

}
