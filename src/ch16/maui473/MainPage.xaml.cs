namespace maui473;

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
        var url = $"https://moonmile-gyakubiki.azurewebsites.net/api/getbook?id={id}";
        var cl = new HttpClient();
        var response = await cl.GetAsync(url);
        var book = await JsonSerializer.DeserializeAsync<Book>(response.Content.ReadAsStream(),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        labelTitle.Text = book.Title;
        labelAuthor.Text = book.Author?.Name;
        labelPublisher.Text = book.Publisher?.Name;
        labelPrice.Text = $"{book.Price} 円";

        // 返信されたJSON形式をそのまま表示
        // string json = await cl.GetStringAsync(url);
        // labelTitle.Text = json;

        SemanticScreenReader.Announce(labelTitle.Text);
        SemanticScreenReader.Announce(labelAuthor.Text);
        SemanticScreenReader.Announce(labelPublisher.Text);
        SemanticScreenReader.Announce(labelPrice.Text);
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


