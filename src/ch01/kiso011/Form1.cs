namespace kiso011;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

private void button1_Click(object sender, EventArgs e)
{
    // ���x���Ɍ��ݓ�����\��
    label2.Text = DateTime.Now.ToString();
}
}
