namespace maui472;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// 日付選択時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void dp_DateSelected(object sender, DateChangedEventArgs e)
    {
		this.text.Text = this.dp.Date.ToString("yyyy年MM月dd日");
    }
}

