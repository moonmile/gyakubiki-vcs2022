namespace error239;

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
        catch (FormatException ex)
        {
            MessageBox.Show(ex.Message, "ÉGÉâÅ[î≠ê∂");
        }
    }
}
