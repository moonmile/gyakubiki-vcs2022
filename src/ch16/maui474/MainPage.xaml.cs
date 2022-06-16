namespace maui474;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        int id = 1;
        var url = $"https://moonmile-gyakubiki.azurewebsites.net/api/books";
        var cl = new HttpClient();
        var response = await cl.GetAsync(url);
        var books = await JsonSerializer.DeserializeAsync<List<Book>>(response.Content.ReadAsStream(),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        this.cv.ItemsSource = books;
        // 返信されたJSON形式をそのまま表示
        // string json = await cl.GetStringAsync(url);
        // labelTitle.Text = json;
    }
}

/// <summary>
/// 書籍クラス
/// </summary>
public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }
    public int Price { get; set; }
    // 関連するテーブル
    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
}
/// <summary>
/// 著者クラス
/// </summary>
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// 出版社クラス
/// </summary>
public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}
