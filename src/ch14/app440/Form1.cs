using System.Configuration;

namespace app440;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var appSettings = configFile.AppSettings.Settings;
        string key = textBox1.Text;
        string value = textBox2.Text;
        if ( appSettings[key] == null )
        {
            appSettings.Add(key, value);
        } else
        {
            appSettings[key].Value = value;
        }
        configFile.Save(ConfigurationSaveMode.Modified);
        MessageBox.Show("ê›íËÇï€ë∂ÇµÇ‹ÇµÇΩ");
    }
}
