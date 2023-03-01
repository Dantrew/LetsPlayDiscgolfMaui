using LetsPlayDiscgolfMaui.Models;
using Microsoft.Maui.Controls.Xaml;

namespace LetsPlayDiscgolfMaui.Views;

public partial class GameRegularPage : ContentPage
{
	public GameRegularPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.GameRegularPageViewModel();
        
    }

    private void GoToNextHole(object sender, EventArgs e)
    {
        
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {        
        await Navigation.PopAsync();
    }

    private void OnStepperValueChangedPlayers(object sender, ValueChangedEventArgs e)
    {


        //if () = e.NewValue;
        
    }
}