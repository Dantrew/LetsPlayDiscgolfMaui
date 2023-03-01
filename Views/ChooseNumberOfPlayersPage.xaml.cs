namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseNumberOfPlayersPage : ContentPage
{
    public ChooseNumberOfPlayersPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.ChooseGamePageViewModel();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }


    private async void ConfirmPlayers(object sender, EventArgs e)
    { 
        await Navigation.PushAsync(new Views.EnterNamePage());
    }

    private void OnStepperValueChangedPlayers(object sender, ValueChangedEventArgs e)
    {
        SessionData.NumberOfPlayers = (int)e.NewValue;
    }
    private void OnStepperValueChangedHoles(object sender, ValueChangedEventArgs e)
    {
        SessionData.NumberOfHoles = (int)e.NewValue;
    }
}