namespace maui475;
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
		int id = int.Parse(textId.Text);
		int price = int.Parse(textPrice.Text);

		var url = $"https://moonmile-gyakubiki.azurewebsites.net/api/postbook";
		var book = new Book()
		{
			Id = id,
			Price = price
		};
		// var data = JsonSerializer.SerializeToUtf8Bytes(book);
		// var json = System.Text.Encoding.UTF8.GetString(data);
		var json = $"{{ \"id\": {id}, \"price\": {price} }}";
		var context = new StringContent(json);
		var cl = new HttpClient();
		var response = await cl.PostAsync(url, context);
		string text = await response.Content.ReadAsStringAsync();
		labelResult.Text = text;
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



