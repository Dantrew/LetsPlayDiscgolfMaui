namespace LetsPlayDiscgolfMaui.Views;
using Sessiondata;

public partial class ChooseNumberOfPlayersPage : ContentPage
{
    public static int chooseNumberOfPlayers;
    public static int chooseNumberOfHoles;
    public static int countHoles = 0;
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
        chooseNumberOfPlayers = (int)Stepper.Value;
        chooseNumberOfHoles = (int)StepperHoles.Value;
    }

    private void OnStepperValueChangedPlayers(object sender, ValueChangedEventArgs e)
    {
        chooseNumberOfPlayers = (int)e.NewValue;
    }
    private void OnStepperValueChangedHoles(object sender, ValueChangedEventArgs e)
    {
        chooseNumberOfHoles = (int)e.NewValue;
    }
}