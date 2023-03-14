namespace LetsPlayDiscgolfMaui.Views;

public partial class GameChallengePage : ContentPage
{
    // GAME NOT IMPLEMENTED. WIP


	public GameChallengePage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}