namespace web428client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string apikey = textBox1.Text;
        var url = $"https://localhost:7144/api/Books/hello";
        var cl = new HttpClient();
        // API-KEY‚ðŽw’è‚·‚é
        cl.DefaultRequestHeaders.Add("X-API-KEY", apikey);
        var response = await cl.GetAsync(url);
        textBox2.Text = await response.Content.ReadAsStringAsync();
    }
}
