namespace error240;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string text = textBox1.Text;
        // 1��������������
        var lst = text.ToList();
        try
        {
            foreach (var ch in lst)
            {
                // �R���N�V�����𓮓I�ɑ��삵�Ă͂����Ȃ�
                if (ch == 'A')
                {
                    lst.Remove(ch);
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "�G���[����");
        }
    }
}
