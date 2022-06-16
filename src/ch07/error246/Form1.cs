namespace error246;

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
            int a = int.Parse(text);
        }
        catch ( FormatException ex ) 
        {
            // 引数が無効の場合
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }
}
