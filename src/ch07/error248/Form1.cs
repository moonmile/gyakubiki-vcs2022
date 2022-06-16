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
            // null文字を追加する
            // コンパイル時に警告がでる
            string t = text.Insert(0, null);

        }
        catch ( ArgumentException ex )
        {
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }
}
