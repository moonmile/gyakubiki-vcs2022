namespace net384;
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string author = textBox1.Text;
        string publisher = textBox2.Text;
        var item = new SearchItem
        {
            AuthorName = author,
            PublisherName = publisher,
        };

        var cl = new HttpClient();
        var url = $"http://localhost:5000/api/Gyakubiki/searchJson";
        string json = JsonSerializer.Serialize(item);
        var context = new StringContent(json);
        context.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var response = await cl.PostAsync(url, context);
        textBox3.Text = await response.Content.ReadAsStringAsync();
    }
}
public class SearchItem
{
    public string AuthorName { get; set; } = "";
    public string PublisherName { get; set; } = "";
}
