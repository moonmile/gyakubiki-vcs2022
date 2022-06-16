using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg182
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 配列を利用する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var ary = new Sample[]
            {
                new Sample{  Id = 100, Name = "増田智明", Address = "東京都" },
                new Sample{  Id = 101, Name = "秀和太郎", Address = "大阪府" },
                new Sample{  Id = 102, Name = "秀和次郎", Address = "北海道" },
                new Sample{  Id = 103, Name = "秀和三郎", Address = "福岡県" },
            };

            listBox1.Items.Clear();
            foreach ( var item in ary)
            {
                listBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// コレクションを利用する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var list = new List<Sample>
            {
                new Sample{  Id = 200, Name = "マスダトモアキ", Address = "東京都" },
                new Sample{  Id = 201, Name = "シュウワタロウ", Address = "大阪府" },
                new Sample{  Id = 202, Name = "シュウワジロウ", Address = "北海道" },
                new Sample{  Id = 203, Name = "シュウワサブロウ", Address = "福岡県" },
            };

            listBox1.Items.Clear();
            foreach ( var item in list)
            {
                listBox1.Items.Add(item);
            }
        }
    }

    /// <summary>
    /// 構造体の定義
    /// </summary>
    public struct Sample
    {
        public int Id;
        public string Name;
        public string Address;

        public override string ToString()
        {
            return $"{Id}: {Name} in {Address}";
        }
    }
}
