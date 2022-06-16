using System.Configuration;

namespace app439;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var settings = ConfigurationManager.ConnectionStrings;
        string key = textBox1.Text;
        var value = settings[key]?.ConnectionString ?? "(none)";
        textBox2.Text = value;
    }
}
