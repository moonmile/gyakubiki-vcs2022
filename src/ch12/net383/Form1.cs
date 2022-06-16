namespace net383;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var cl = new HttpClient();
        var url = $"http://localhost:5000/api/Gyakubiki/search";
        var dic = new Dictionary<string, string>();
        dic.Add("Title", textBox1.Text);
        var context = new FormUrlEncodedContent(dic);
        var response = await cl.PostAsync(url, context);
        textBox2.Text = await response.Content.ReadAsStringAsync();
    }
}
