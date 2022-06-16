namespace maui477;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnClicked(object sender, EventArgs e)
	{
		 await DisplayAlert("逆引き大全", "警告メッセージを表示します","OK");
	}
}

