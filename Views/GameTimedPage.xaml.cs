namespace LetsPlayDiscgolfMaui.Views;

public partial class GameTimedPage : ContentPage
{
	public GameTimedPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}