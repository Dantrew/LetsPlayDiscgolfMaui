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
        if (vm.UserName(userName.Text).Result == "That username is already taken")
        {
            WrongInput.Text = vm.UserName(userName.Text).Result;
        }
        else if (vm.Mail(email.Text).Result == "Thats not a correct email" || vm.Mail(email.Text).Result == "That email is already taken")
            WrongInput.Text = vm.Mail(email.Text).Result;
        else
        {
            MainPage.loggedIn = true;
            getPlayers.LoggedInUser(userName.Text);
            await vm.UserRegistration(userName.Text, password.Text, email.Text, playerName.Text);
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
    }
}