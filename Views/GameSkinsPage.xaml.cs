namespace LetsPlayDiscgolfMaui.Views;

public partial class GameSkinsPage : ContentPage
{
	public GameSkinsPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}