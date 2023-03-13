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
            ButtonLogOut.IsVisible = true;
            ButtonStatistic.IsVisible = true;
        }
        else if(MainPage.loggedIn == false) 
        {
            ButtonLogOut.Text = "Quit";
            ButtonLogOut.IsVisible = true;
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
        city = getCityName.Text;
        if (sender == GoToTimedPage)
        {
            chooseGame = "GameTimed";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToRegularPage)
        {
            chooseGame = "GameRegular";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        else if (sender == GoToSkinsPage)
        {
            chooseGame = "GameSkins";
            await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        }
        //else if (sender == GoToChallengePage)
        //{
        //    chooseGame = "GameChallenge";
        //    await Navigation.PushAsync(new Views.ChooseNumberOfPlayersPage());
        //}
    }

    private async void OnStatisticClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ShowStatisticPage());
    }
}