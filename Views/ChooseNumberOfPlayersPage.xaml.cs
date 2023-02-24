namespace LetsPlayDiscgolfMaui.Views;

public partial class ChooseNumberOfPlayersPage : ContentPage
{
	public ChooseNumberOfPlayersPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ChosenGamesClicked(object sender, EventArgs e)
    {
        if (Sessiondata.SessionData.GameType == "GameTimedPage")
        {
            await Navigation.PushAsync(new Views.GameTimedPage());
        }
        else if (Sessiondata.SessionData.GameType == "GameSkinsPage")
        {
            await Navigation.PushAsync(new Views.GameSkinsPage());
        }
        else if (Sessiondata.SessionData.GameType == "GameChallengePage")
        {
            await Navigation.PushAsync(new Views.GameChallengePage());
        }
    }
}