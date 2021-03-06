namespace error245;

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
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }
    private int calc(int a, int b)
    {
        // 0除算をチェックする
        if (b == 0)
        {
            // 例外を発生させる
            throw new SampleExcepition("0で除算はできません");
        }
        return a / b;
    }
}

/// <summary>
/// 独自の例外クラスを定義する
/// </summary>
public class SampleExcepition : Exception
{
    public SampleExcepition() : base() 
    {
    }
    public SampleExcepition(string message) : base(message) 
    { 
    }
    public SampleExcepition(string message, Exception inner ) 
        : base( message, inner ) 
    { 
    }
}

