using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui069
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 14日間選択できる
            monthCalendar1.MaxSelectionCount = 14;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startDay = monthCalendar1.SelectionStart;
            var endDay = monthCalendar1.SelectionEnd;
            int days = endDay.Subtract(startDay).Days + 1;

            label4.Text = startDay.ToLongDateString();
            label5.Text = endDay.ToLongDateString();
            label6.Text = $"{days}日間";

        }
    }
}
