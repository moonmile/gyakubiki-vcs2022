namespace app436;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // �e�L�X�g�`���Ńy�[�X�g����
        if ( Clipboard.ContainsText() )
        {
            var text = Clipboard.GetText();
            textBox1.Text = text; 
        }
    }
}
