namespace app435;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Clipboard.Clear();
        Clipboard.SetImage(pictureBox1.Image);
        MessageBox.Show("�N���b�v�{�[�h�ɃR�s�[���܂���");
    }
}
