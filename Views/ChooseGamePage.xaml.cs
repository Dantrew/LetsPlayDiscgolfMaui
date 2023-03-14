namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseGamePage : ContentPage
{
    public static string chooseGame;
    public static string city;
    public ChooseGamePage()
    {
        InitializeComponent();
        CheckLogedInStatus();
        BindingContext = new ViewModels.ChooseGamePageViewModel().Weather;     
    }

    private void CheckLogedInStatus()
    {
        if (MainPage.loggedIn == true) 
        { 
            _buttonLogOut.IsVisible = true;
            _buttonStatistic.IsVisible = true;
        }
        else if(MainPage.loggedIn == false) 
        {
            _buttonLogOut.Text = "Quit";
            _buttonLogOut.IsVisible = true;
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
        _buttonLogOut.IsVisible = false;
        _buttonStatistic.IsVisible = false;
    }

    private async void ChosenGamesClicked(object sender, EventArgs e)
    {
        city = getCityName.Text;
        if (sender == _goToTimedPage)
        {
            chooseGame = "GameTimed";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == _goToRegularPage)
        {
            chooseGame = "GameRegular";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == _goToSkinsPage)
        {
            chooseGame = "GameSkins";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        // Future implement challenge play
        // else if (sender == GoToChallengePage)
        // {
        //    chooseGame = "GameChallenge";
        //    await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        // }
    }

    private async void OnStatisticClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ShowStatisticPage());
    }
}