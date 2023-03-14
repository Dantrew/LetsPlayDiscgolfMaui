using LetsPlayDiscgolfMaui.Sessiondata;

namespace LetsPlayDiscgolfMaui.Views;

public partial class RegisterPage : ContentPage
{
    ViewModels.RegisterPageViewModel vm = new ViewModels.RegisterPageViewModel();
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (vm.UserName(_userName.Text).Result == "That username is already taken")
        {
            _wrongInput.Text = vm.UserName(_userName.Text).Result;
        }
        else if (vm.Mail(_email.Text).Result == "Thats not a correct email" || vm.Mail(_email.Text).Result == "That email is already taken")
            _wrongInput.Text = vm.Mail(_email.Text).Result;
        else
        {
            MainPage.loggedIn = true;
            getPlayers.LoggedInUser(_userName.Text);
            await vm.UserRegistration(_userName.Text, _password.Text, _email.Text, _playerName.Text);
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
    }
}