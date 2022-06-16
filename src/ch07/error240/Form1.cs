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
        // 1文字ずつ分割する
        var lst = text.ToList();
        try
        {
            foreach (var ch in lst)
            {
                // コレクションを動的に操作してはいけない
                if (ch == 'A')
                {
                    lst.Remove(ch);
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }
}
