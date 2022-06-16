namespace maui469;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		// 初期値は表示（オン）
		this.sw.IsToggled = true;
	}

	/// <summary>
	/// オン/オフで、画像の表示を切り替える
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void sw_Toggled(object sender, ToggledEventArgs e)
    {
		if ( sw.IsToggled == true )
        {
			this.img.IsVisible = true;
        }
		else
        {
			this.img.IsVisible = false;
        }
    }
}

