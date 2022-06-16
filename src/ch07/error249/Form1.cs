namespace error249;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string path = textBox1.Text;
        try
        {
            var reader = System.IO.File.OpenText(path);
            var text = reader.ReadToEnd();
            reader.Close();
        } 
        catch ( System.IO.IOException ex )
        {
            // 読み込みに失敗したときに例外が発生する
            MessageBox.Show(ex.Message, "エラー発生");
        }
    }
}
