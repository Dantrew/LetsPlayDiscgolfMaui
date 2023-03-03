namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseGamePage : ContentPage
{
    public static string chooseGame;
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
            chooseGame = "GameTimedPage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToRegularPage)
        {
            chooseGame = "GameRegularPage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToSkinsPage)
        {
            chooseGame = "GameSkinsPage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToChallengePage)
        {
            chooseGame = "GameChallengePage";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
    }
}