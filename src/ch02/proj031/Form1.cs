namespace proj031;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

private void button1_Click(object sender, EventArgs e)
{
    // ���\�[�X���當�����\��
    this.label1.Text = Properties.Resources.subject;
    // ���\�[�X����摜��\��
    this.pictureBox1.Image = Properties.Resources.cock;
    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
}
}
