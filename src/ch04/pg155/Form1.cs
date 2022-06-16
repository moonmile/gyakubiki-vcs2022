using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg155
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Cup オブジェクトの作成
        Cup _cup = new Cup();

        private void button1_Click(object sender, EventArgs e)
        {
            _cup.add(20);
            label2.Text = $"Value is {_cup.Value}";
        }
    }

    class Cup
    {
        int _value = 0;         // 内容量
        const int MAX = 100;    // 最大値
        
        /// <summary>
        /// 内容量を増やすメソッド
        /// </summary>
        /// <param name="x"></param>
        public void add( int x )
        {
            _value += x;
            if ( _value > MAX )
            {
                _value = MAX;
            }
            // 戻り値はない
        }
        public int Value => _value;
    }
}
