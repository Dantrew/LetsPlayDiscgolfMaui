namespace LetsPlayDiscgolfMaui.Views;

public partial class ShowWinnerPage : ContentPage
{
	public ShowWinnerPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void ChosenGamesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ChooseGamePage());
    }
}