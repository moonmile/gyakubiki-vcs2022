namespace maui478;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnClicked(object sender, EventArgs e)
	{
		string url = "https://www.shuwasystem.co.jp/";
		await Browser.OpenAsync(url);
	}
}

