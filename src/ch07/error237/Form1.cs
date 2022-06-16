namespace error237;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string text = textBox1.Text;
        int x = 0;
        try
        {
            x = int.Parse(text);
        }
        catch (Exception ex)
        {
            MessageBox.Show("予期しないエラーが発生しました", "エラー発生");
        }

    }
}
