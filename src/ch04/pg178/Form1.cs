using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg178
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true; 

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            label3.Text = "縦";
            label4.Text = "横";
            textBox4.Visible = true;
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "高さ";
            label4.Text = "底辺";
            textBox4.Visible = true;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "半径";
            label4.Text = "";
            textBox4.Visible = false;

        }

        /// <summary>
        /// 面積を計算する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IShape shape;
            if ( radioButton1.Checked == true )
            {
                shape = new Square()
                {
                    Height = int.Parse(textBox3.Text),
                    Width = int.Parse(textBox4.Text),
                };
            } 
            else if (radioButton2.Checked == true)
            {
                shape = new Triangle()
                {
                    Height = int.Parse(textBox3.Text),
                    Width = int.Parse(textBox4.Text),
                };
            } 
            else if (radioButton3.Checked == true)
            {
                shape = new Circle()
                {
                    Radius = int.Parse(textBox3.Text),
                };
            } 
            else
            {
                
                return;
            }
            // X座標とY座標はまとめて設定できる
            shape.X = int.Parse(textBox1.Text);
            shape.Y = int.Parse(textBox2.Text);
            // 面積を計算する
            label6.Text = shape.Area.ToString("0.00");
        }

    }

    public interface IShape
    {
        public int X { get; set; }   // X座標
        public int Y { get; set; }   // Y座標
        public double Area { get; }   // 面積
    }

    public class Triangle : IShape
    {
        int _x;
        int _y;
        int _width; // 底辺
        int _height; // 高さ

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width {  get  => _width; set => _width = value;}
        public int Height {  get => _height; set => _height = value; }
        public double Area => _width * _height / 2.0;
    }

    public class Square : IShape
    {
        int _x;
        int _y;
        int _width; // 底辺
        int _height; // 高さ

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public double Area => _width * _height ;
    }

    public class Circle : IShape
    {
        int _x;
        int _y;
        int _radius; // 半径

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Radius { get => _radius; set => _radius = value; }
        public double Area => _radius * _radius * Math.PI;
    }
}
