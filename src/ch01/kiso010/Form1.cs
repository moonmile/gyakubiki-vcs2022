namespace kiso010;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

/// <summary>
/// テキストを追加
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button1_Click(object sender, EventArgs e)
{
    // 引数のあるメソッドの呼び出し
    textBox2.AppendText(textBox1.Text + "\r\n");
}

/// <summary>
/// テキストを削除
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button2_Click(object sender, EventArgs e)
{
    // 引数のないメソッドの呼び出し
    textBox2.Clear();

}
}
