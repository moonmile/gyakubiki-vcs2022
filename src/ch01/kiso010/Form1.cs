namespace kiso010;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

/// <summary>
/// �e�L�X�g��ǉ�
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button1_Click(object sender, EventArgs e)
{
    // �����̂��郁�\�b�h�̌Ăяo��
    textBox2.AppendText(textBox1.Text + "\r\n");
}

/// <summary>
/// �e�L�X�g���폜
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button2_Click(object sender, EventArgs e)
{
    // �����̂Ȃ����\�b�h�̌Ăяo��
    textBox2.Clear();

}
}
