namespace net390;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);
        var url = $"http://localhost:5000/api/Gyakubiki/checkUserAgent";
        var cl  = new HttpClient();
        cl.DefaultRequestHeaders.Add("User-Agent", "Gyakubiki-App");
        var response = await cl.GetStringAsync(url);
        textBox2.Text = response;
    }
}
