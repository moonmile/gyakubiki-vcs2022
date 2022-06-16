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
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }

    /// <summary>
    /// 文字列を数値に変換する関数
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private int sample( string text )
    {
        // 数値に変換できないときは例外が発生する
        int a = int.Parse(text );
        return a;
    }
}
