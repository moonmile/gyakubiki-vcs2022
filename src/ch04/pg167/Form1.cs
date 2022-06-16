using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg167
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Sample? _obj = null;

        /// <summary>
        /// インスタンスの生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _obj = new Sample(textBox1.Text);
            label3.Text = _obj.Id;
        }

        /// <summary>
        /// 名前を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (_obj == null) return;
            _obj.Name = textBox1.Text;
            // _obj.Id = "xxxxxxx"; // IDプロパティは変更できない
            label3.Text = _obj.Id;

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
        public Sample(string name)
        {
            _name = name;
            _id = Guid.NewGuid().ToString();
        }
        // 読み取り専用のプロパティ
        public string Id
        {
            get {  return _id; }
        }
        // 読み書きできるプロパティ
        public string Name
        {
            get {  return _name; }
            set { _name = value; }
        }
    }
}
