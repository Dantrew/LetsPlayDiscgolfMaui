namespace LetsPlayDiscgolfMaui;

public partial class MainPage : ContentPage
{
    public static bool loggedIn;
    ViewModels.StartPageViewModel vm = new ViewModels.StartPageViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void GoToGamesAsLogedInClicked(object sender, EventArgs e)
    {
        if (vm.CheckInlog(UserName.Text, Password.Text))
        {
            loggedIn = true;
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
        else
        {
            WrongInput.Text = "Wrong Username or password";
        }
    }

    private async void GoToGamesAsGuestClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ChooseGamePage());
    }

    private void GoToRegisterClicked(object sender, EventArgs e)
    {

    }
}

