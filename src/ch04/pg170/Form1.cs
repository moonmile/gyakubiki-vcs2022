using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg170
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Sample _obj;

        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = new Sample("秀和太郎");
            // イベントハンドラを追加する
            _obj.OnChangedName += _obj_OnChangedName;
            label3.Text = _obj.Name;
            label4.Text = "";
        }

        private void _obj_OnChangedName(DateTime time)
        {
            label3.Text = _obj.Name;
            label4.Text = $"Name を変更した {time}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // イベントを発生させる
            _obj.Name = "秀和次郎";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // イベントを削除する
            _obj.OnChangedName -= _obj_OnChangedName;
        }
    }

    public class Sample
    {
        private string _name = "";
        private DateTime _modified;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public Sample( string name )
        {
            _name = name;
        }

        /// <summary>
        /// イベントの定義
        /// </summary>
        public event Action<DateTime>? OnChangedName;

        public string Name
        {
            get {  return _name; }
            set
            {
                _name = value;
                _modified = DateTime.Now;
                OnChangedName?.Invoke(_modified);
                // 以下のように if 文を使ってもよい
                /*
                if ( OnChangedName != null )
                {
                    OnChangedName( _modified );
                }
                */
            }
        }

    }
}
