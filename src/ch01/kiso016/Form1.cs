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
                // �`�F�b�N����Ă��鎞�̏���������
                MessageBox.Show("�I����Ԃł�");
            }
            else
            {
                // �`�F�b�N����Ă��Ȃ����̏���������
                MessageBox.Show("���I����Ԃł�");
            }

        }
    }
}