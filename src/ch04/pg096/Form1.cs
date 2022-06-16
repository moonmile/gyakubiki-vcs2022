using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg096
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            // 行頭に「//」を記述すると、行全体がコメントになります
            i = 100 * 2; // 行の途中からもコメントが書けます

            // 次の行は行頭に「//」があるので実行されません
            // i += 100 ;

            /*
             * 複数行のブロックコメントです
             * 
             * 
             */
            MessageBox.Show($"i = {i}", "確認");
        }
    }
}
