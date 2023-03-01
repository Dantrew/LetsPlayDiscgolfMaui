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
}