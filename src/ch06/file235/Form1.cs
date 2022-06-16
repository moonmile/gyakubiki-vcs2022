using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file235
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// JSON形式で書き出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var person = new Person
            {
                Id = 100,
                Name = "マスダトモアキ",
                Age = 53,
                Address = "東京都",
            };

            string path = textBox1.Text;
            string json = System.Text.Json.JsonSerializer.Serialize(person);
            System.IO.File.WriteAllText(path, json);
            MessageBox.Show("JSON形式で書き出しました");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            var json = System.IO.File.ReadAllText(path);
            Person? person = System.Text.Json.JsonSerializer.Deserialize<Person>(json);
            MessageBox.Show("JSON形式を読み込みました\n"
                + $"Name: {person?.Name}\n" 
                + $"Address: {person?.Address}");
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";
    }
}
