namespace kiso016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true )
            {
                // チェックされている時の処理を書く
                MessageBox.Show("選択状態です");
            }
            else
            {
                // チェックされていない時の処理を書く
                MessageBox.Show("未選択状態です");
            }

        }
    }
}