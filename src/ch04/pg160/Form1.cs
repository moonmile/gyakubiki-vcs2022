using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg160
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 2つの数値を加算する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int add( int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// 2つの文字列を連結する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        string add(string x, string y)
        {
            return x + " " + y;
        }

        /// <summary>
        /// 指定回数繰り返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        string add( string x, int n )
        {
            string result = "";
            for ( int i=0; i<n; i++ )
            {
                result += x + " ";
            }
            return result;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = add(10, 20).ToString();
            label5.Text = add("masdua", "tomoaki");
            label6.Text = add("ABC", 5);
        }
    }
}
