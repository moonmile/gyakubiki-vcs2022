namespace debug251;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string text = textBox1.Text;
        // 数値でない場合、例外が発生する
        int x = int.Parse(text);

    }
}
