namespace error247;

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
            // 10•¶š–Ú‚ğæ“¾‚·‚é
            string t = text.Substring(10, 1);
        } 
        catch ( ArgumentException ex )
        {
            MessageBox.Show(ex.Message, "ƒGƒ‰[”­¶");
        }
    }
}
