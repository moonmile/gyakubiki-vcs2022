namespace maui476;

public partial class NextPage : ContentPage
{
    public NextPage()
    {
        InitializeComponent();
    }
    private void OnPrevClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}
