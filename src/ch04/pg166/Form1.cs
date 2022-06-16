using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg166
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var o = new Sample(textBox1.Text);
            label3.Text = o.Id;
        }
    }

    /// <summary>
    /// Sample クラス
    /// </summary>
    public class Sample
    {
        private string _id;
        private string _name;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Sample( string name )
        {
            _name = name;
            _id = Guid.NewGuid().ToString();
        }
        // 読み取り用のプロパティ
        public string Name => _name;
        public string Id => _id;
    }
}
