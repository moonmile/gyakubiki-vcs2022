namespace error242;

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
            int a = int.Parse(text);
            
        } 
        catch ( Exception ex )
        {
            MessageBox.Show(ex.GetType().Name, "ÉGÉâÅ[î≠ê∂");
        }

    }
}
