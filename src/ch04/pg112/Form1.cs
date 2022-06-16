using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace pg112
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public record Person ( string Name, int Age, string Address );


        private void button1_Click(object sender, EventArgs e)
        {
            var a = new Person("マスダトモアキ", 53, "東京");
            label1.Text = a.ToString();
            label5.Text = a.Name;
            label6.Text = a.Age.ToString();
            label7.Text = a.Address;
        }

        public record Person2 : Person
        {
            public Person2(string Name, int Age, string Address) 
                : base(Name, Age, Address)  { }
            public override string ToString()
            {
                return $"{Name} ({Age}) in {Address}";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var items = new List<Person2>() {
                new Person2( "masuda", 50, "Tokyo"),
                new Person2( "yamada", 40, "Osaka"),
                new Person2( "sato",30, "Fukuoka"),
                new Person2( "kato",20, "Hokkaido"),
                };
            listBox1.Items.Clear();
            foreach ( var it in items )
            {
                listBox1.Items.Add(it);
            }
        }
    }
}
