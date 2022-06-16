using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dt1 = DateTime.Today;
            label3.Text = _dt1.ToLongDateString();
            monthCalendar1.DateChanged += (_,__) =>
            {
                _dt2 = monthCalendar1.SelectionStart;
                label4.Text = _dt2.ToLongDateString();
            };
        }

        DateTime _dt1, _dt2;

        private void button1_Click(object sender, EventArgs e)
        {
            var span = _dt2.Subtract(_dt1);
            label5.Text = $"{span.Days} 日間";
        }
    }
}
