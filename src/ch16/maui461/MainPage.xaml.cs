namespace maui461;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnClicked(object sender, EventArgs e)
    {
		labelCounter.Text = $"{count}";
		count++;
		labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
	}
}

