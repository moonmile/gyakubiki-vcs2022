using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg153
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 数値を受け取るメソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int add(int x, int y)
        {
            return x + y;
        }
        /// <summary>
        /// 文字列を受け取るメソッド
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        string append(string s1, string s2)
        {
            return $"{s1} {s2} 様宛";
        }

        /// <summary>
        /// オブジェクトを受け取るメソッド
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        string makeStr(Person p)
        {
            return $"{p.Name} ({p.Age}) in {p.Address}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 20;
            int ans = add(x, y);
            label4.Text = ans.ToString();

            string s1 = "Mausda";
            string s2 = "Tomoaki";
            string s3 = append(s1, s2);
            label5.Text = s3;

            var p = new Person
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都",
            };
            string text = makeStr(p);
            label6.Text = text;
        }
    }
    public class Person 
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";
   }
}
