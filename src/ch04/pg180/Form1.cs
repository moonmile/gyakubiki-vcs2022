using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg180
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = new List<Person>();

            lst.Add(new Person {  Name = "増田智明", Age = 53, Address = "東京都"});
            lst.Add(new Person { Name = "秀和太郎", Age = 30, Address = "大阪府" });
            lst.Add(new Person { Name = "秀和次郎", Age = 25, Address = "北海道" });
            lst.Add(new Person { Name = "秀和三郎", Age = 20, Address = "福岡県" });

            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }

    /// <summary>
    /// クラスを分割して編集する
    /// </summary>
    public partial class Person
    {
        static int _seed = 0;
        int _id;
        public int Id => _id;

        public Person()
        {
            _seed++;
            _id = _seed;
        }
        public override string ToString()
        {
            return $"{Id}: {Name} ({Age}) in {Address}";
        }
    }
}
