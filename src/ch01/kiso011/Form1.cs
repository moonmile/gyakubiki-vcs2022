namespace kiso011;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

private void button1_Click(object sender, EventArgs e)
{
    // ラベルに現在日時を表示
    label2.Text = DateTime.Now.ToString();
}
}
