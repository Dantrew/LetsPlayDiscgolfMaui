namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseGamePage : ContentPage
{
    public static string chooseGame;
    public ChooseGamePage()
    {
        InitializeComponent();
        CheckLogedInStatus();
        BindingContext = new ViewModels.GamePageViewModel().Weather;
        
    }

    private void CheckLogedInStatus()
    {
        if (MainPage.loggedIn == true) 
        { 
            ButtonLogOut.IsVisible = true;
            ButtonStatistic.IsVisible = true;
        }
    }
    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        ResetLoginStatus();
        await Navigation.PopToRootAsync();
    }

    private void ResetLoginStatus()
    {
        MainPage.loggedIn = false;
        ButtonLogOut.IsVisible = false;
        ButtonStatistic.IsVisible = false;
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