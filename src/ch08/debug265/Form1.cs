using System.Diagnostics;

namespace debug265;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int x = int.Parse(textBox1.Text);
        int ans = sample(x);
        MessageBox.Show($"�v�Z����: {ans}");
    }

    private int sample( int x )
    {
        // �͈͂��`�F�b�N����
        if (0 <= x && x <= 100)
        {
            return x * x;
        }
        else
        {
            Debug.Fail("�͈͊O�ł�");
            return 0;
        }
    }
}
