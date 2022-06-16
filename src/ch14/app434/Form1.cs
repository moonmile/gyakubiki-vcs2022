namespace app434;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Clipboard.Clear();
        Clipboard.SetText(textBox1.Text);
        MessageBox.Show("クリップボードにコピーしました", "確認");
    }
}
