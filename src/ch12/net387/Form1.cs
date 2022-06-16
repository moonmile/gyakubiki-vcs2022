using System.Text.Json;

namespace net387;

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
        var url = $"http://localhost:5000/api/Gyakubiki/searchApiKey";
        string json = JsonSerializer.Serialize(item);
        var context = new StringContent(json);
        // コンテキストタイプを指定する
        context.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var response = await cl.PostAsync(url, context);
        json = await response.Content.ReadAsStringAsync();
        // JSONの大文字小文字を区別せずにデシリアライズする
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var books = JsonSerializer.Deserialize<List<Book>>(json, options);
        listBox1.Items.Clear();
        if ( books != null )
        {
            foreach (var it in books)
            {
                listBox1.Items.Add($"{it.Title} {it.Price}円");
            }
        }
    }
}
public class SearchItem
{
    public string AuthorName { get; set; } = "";
    public string PublisherName { get; set; } = "";
}

/// <summary>
/// 書籍クラス
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }
    public int Price { get; set; }

    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; }
}
/// <summary>
/// 著者クラス
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// 出版社クラス
/// </summary>
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}

