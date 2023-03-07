namespace LetsPlayDiscgolfMaui.Views;

public partial class ShowStatisticPage : ContentPage
{
    ViewModels.ShowStatisticPageViewModel vm = new ViewModels.ShowStatisticPageViewModel();
    public ShowStatisticPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void RoundsToString()
    {
        
        foreach(var game in vm.GameInfos) 
        { 
            foreach(var g in game.ThrowsPerHole)
            {
               
            }
        }
    }

    private async void OnSeeAllRoundsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ShowFullStatisticPage());
    }
}