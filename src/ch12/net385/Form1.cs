using System.Text.Json;

namespace net385;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);
        var cl = new HttpClient();
        var url = $"http://localhost:5000/api/Gyakubiki/{id}";
        var response = await cl.GetStringAsync(url);
        // JSONの大文字小文字を区別せずにデシリアライズする
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var book = JsonSerializer.Deserialize<Book>(response, options);

        if (book != null)
        {
            textBox2.Text =
@$"書名：{book.Title} 
著者名：{book.Author?.Name} 
出版社名：{book!.Publisher?.Name} 
価格：{book.Price} 
";
        }
    }
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
