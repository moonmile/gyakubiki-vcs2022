namespace error241;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string text = textBox1.Text;
        try
        {
            int x = sample(text);
        }
        catch ( Exception ex )
        {
            MessageBox.Show(ex.Message, "�G���[����");
        }
    }

    /// <summary>
    /// ������𐔒l�ɕϊ�����֐�
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private int sample( string text )
    {
        // ���l�ɕϊ��ł��Ȃ��Ƃ��͗�O����������
        int a = int.Parse(text );
        return a;
    }
}
