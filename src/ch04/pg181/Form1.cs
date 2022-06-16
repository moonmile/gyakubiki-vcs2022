using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg181
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 構造体の利用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SampleStruct obj;
            obj.Name = "マスダトモアキ";
            obj.Age = 53;
            obj.Address = "板橋区";
            label2.Text = obj.ToString();
        }

        /// <summary>
        /// クラスの利用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SampleClass obj = new SampleClass();
            obj.Name = "増田智明";
            obj.Age = 53;
            obj.Address = "東京都";
            label2.Text = obj.ToString();
        }
    }

    /// <summary>
    /// 構造体の定義
    /// </summary>
    public struct SampleStruct
    {
        public string Name;
        public int Age;
        public string Address;

        public override string ToString()
        {
            return $"{Name} ({Age}) in {Address}"; 
        }
    }
    /// <summary>
    /// クラスの定義
    /// </summary>
    public struct SampleClass
    {
        public string Name {  get; set; }
        public int Age {  get; set; }
        public string Address {  get; set; }

        public override string ToString()
        {
            return $"{Name} ({Age}) in {Address}";
        }
    }

}
