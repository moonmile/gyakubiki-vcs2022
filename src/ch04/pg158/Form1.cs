using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg158
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string [] changeArray( string[] ary )
        {
            // 配列内の文字列をすべて大文字に変換する
            var result = new string[ary.Length];
            for ( int i = 0; i < ary.Length; i++ )
            {
                result[i] = ary[i].ToUpper();
            }
            return result; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ary =
            {
                "microsoft",
                "apple",
                "ibm",
                "oracle",
                "shuwasystem",
            };
            listBox1.Items.Clear();
            listBox1.Items.AddRange(ary);
            var resullt = changeArray(ary);
            listBox2.Items.Clear();
            listBox2.Items.AddRange(resullt);
        }

        List<string> changeList(List<string> lst)
        {
            // リスト内の文字列をすべて大文字に変換する
            var result = new List<string>();
            foreach ( var it in lst )
            {
                result.Add(it.ToUpper());
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> lst =
                new List<string> {
                    "orange",
                    "apple",
                    "raspberry",
                    "nano",
                    "banana",
            };
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
            var resullt = changeList(lst);
            listBox2.Items.Clear();
            listBox2.Items.AddRange(resullt.ToArray());
        }
    }
}
