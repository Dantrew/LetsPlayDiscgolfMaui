using LetsPlayDiscgolfMaui.Sessiondata;
using MongoDB.Driver.Core.Authentication;

namespace LetsPlayDiscgolfMaui;

public partial class MainPage : ContentPage
{
    public static bool loggedIn;
    ViewModels.StartPageViewModel vm = new ViewModels.StartPageViewModel();
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();


    public MainPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void GoToGamesAsLogedInClicked(object sender, EventArgs e)
    {
        if (vm.CheckInlog(_userName.Text, _password.Text))
        {
            loggedIn = true;
            getPlayers.LoggedInUser(_userName.Text);
            ResetInput();
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
        else
        {
            _wrongInput.Text = "Wrong Username or password";
        }
    }

    private async void GoToGamesAsGuestClicked(object sender, EventArgs e)
    {
        _wrongInput.Text = "";
        ResetInput();
        await Navigation.PushAsync(new Views.ChooseGamePage());
    }

    private async void GoToRegisterClicked(object sender, EventArgs e)
    {
        _wrongInput.Text = "";
        ResetInput();
        await Navigation.PushAsync(new Views.RegisterPage());
    }

    public void ResetInput()
    {
        _userName.Text = string.Empty;
        _password.Text = string.Empty;
    }
}

