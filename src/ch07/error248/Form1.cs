namespace error248;

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
            // null������ǉ�����
            // �R���p�C�����Ɍx�����ł�
            string t = text.Insert(0, null);

        }
        catch ( ArgumentException ex )
        {
            MessageBox.Show(ex.Message, "�G���[����");
        }
    }
}
