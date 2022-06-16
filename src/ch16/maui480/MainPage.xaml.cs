namespace maui480;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnClicked(object sender, EventArgs e)
	{
		var location = await Geolocation.GetLastKnownLocationAsync();
		labelLatitude.Text = $"緯度: {location.Latitude:0.000}";
		labelLongitude.Text = $"経度: {location.Longitude:0.000}";
		labelAltitude.Text = $"高度: {location.Altitude:0.000}";
	}
}

