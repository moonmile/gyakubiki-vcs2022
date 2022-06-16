namespace error250;

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
            var image = Image.FromFile(path);
        }
        catch ( System.IO.FileNotFoundException ex )
        {
            MessageBox.Show(ex.Message, "ÉGÉâÅ[î≠ê∂");
        }
    }
}
