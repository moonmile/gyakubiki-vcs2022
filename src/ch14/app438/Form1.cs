using System.Configuration;

namespace app438;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var appSettings = ConfigurationManager.AppSettings;
        string key = textBox1.Text;
        string value = appSettings[key] ?? "(none)";
        textBox2.Text = value;
    }
}
