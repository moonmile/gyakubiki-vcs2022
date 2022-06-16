namespace error244;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int a = int.Parse(textBox1.Text);
        int b = int.Parse(textBox2.Text);
        try
        {
            int ans = calc(a, b);
            MessageBox.Show($"ans: {ans}");
        }
        catch (Exception ex )
        {
            MessageBox.Show(ex.Message, "�G���[����");
        }

    }

    private int calc( int a , int b )
    {
        // 0���Z���`�F�b�N����
        if ( b == 0 )
        {
            // ��O�𔭐�������
            throw new DivideByZeroException("0�ŏ��Z�͂ł��܂���");
        }
        return a / b;
    }
}
