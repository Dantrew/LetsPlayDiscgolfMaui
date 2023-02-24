namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseGamePage : ContentPage
{
    public ChooseGamePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.GamePageViewModel().Weather;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ChosenGamesClicked(object sender, EventArgs e)
    {
        if (sender == GoToTimedPage)
        {
            Sessiondata.SessionData.GameType = "GameTimedPage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToSkinsPage)
        {
            Sessiondata.SessionData.GameType = "GameSkinsPage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToChallengePage)
        {
            Sessiondata.SessionData.GameType = "GameChallengePage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
    }
}