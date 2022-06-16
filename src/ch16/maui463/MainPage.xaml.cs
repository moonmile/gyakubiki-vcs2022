namespace maui463;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		this.LayoutChanged += MainPage_LayoutChanged;
	}

	private void MainPage_LayoutChanged(object sender, EventArgs e)
	{
		var lst = new List<Card>();
		lst.Add(new Card() { ImageUrl = "cock.jpg", Name = "Cooking", Location = "Japan" });
		lst.Add(new Card() { ImageUrl = "book.jpg", Name = "Book Boy", Location = "Japan" });
		lst.Add(new Card() { ImageUrl = "dotnet_bot.svg", Name = ".NET", Location = "USA" });
		this.cv.ItemsSource = lst;
	}
}


public class Card
{
	public string ImageUrl { get; set; } = "";
	public string Name { get; set; } = "";
	public string Location { get; set; } = "";

}

