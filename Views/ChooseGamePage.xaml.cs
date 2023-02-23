namespace LetsPlayDiscgolfMaui.Views;

public partial class ChooseGamePage : ContentPage
{
	public ChooseGamePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.GamePageViewModel().Weather;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}