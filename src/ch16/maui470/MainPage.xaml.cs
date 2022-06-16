namespace maui470;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        this.Appearing += MainPage_Appearing;
	}

    private void MainPage_Appearing(object sender, EventArgs e)
    {
		this.slider.Value = this.img.Height;
		this.label.Text = $"{slider.Value:0.00}";
	}

	private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		double height = this.slider.Value;
		this.img.HeightRequest = height;
		this.label.Text = $"{height:0.00}";
	}
}

