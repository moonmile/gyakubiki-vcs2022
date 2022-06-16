using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg179
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new Person()
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都"
            };
            this.ShowPerson(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var p = new SubPerson()
            {
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都"
            };
            this.ShowPerson(p);

        }
        void ShowPerson(Person p)
        {
            // 呼び出し元が Person か SubPerson で結果が異なる
            label3.Text = $"{p.Name} ({p.Age}) in {p.Address}";
        }
    }

    /// <summary>
    /// Person.Age プロパティを継承元で書き換え
    /// られないように sealed する
    /// </summary>
    // public sealed class Person
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";
    }

    public class SubPerson : Person
    {
        public int Age
        {
            get { return base.Age ; } 
            set { base.Age = value - 20; }  // サバを読む
        }
    }
}
