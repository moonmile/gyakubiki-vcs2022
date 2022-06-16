namespace debug262;
using System.Diagnostics;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        for ( int i= 0; i < 10; i++ )
        {
            Debug.WriteLine(i * 2);
        }
    }
}
