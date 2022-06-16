using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg154
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 数値を返すメソッド
        /// </summary>
        /// <returns></returns>
        int add( int x, int y )
        {
            return x + y; 
        }
        /// <summary>
        /// 文字列を返すメソッド
        /// </summary>
        /// <returns></returns>
        string calc( int x, int y )
        {
            return $"{x} と {y} を足すと {x + y} になります";
        }

        Person makePerson( string name , int age, string address )
        {
            var p = new Person();
            p.Name = name;
            p.Age = age;
            p.Address = address;
            return p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 20;
            int v = add(x, y);
            label4.Text = v.ToString();

            string s = calc(x, y);
            label5.Text = s;

            Person p = makePerson("ますだともあき", 53, "TOKYO");
            label6.Text = $"{p.Name} ({p.Age}) in {p.Address}";


        }
    }
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";
    }

}
