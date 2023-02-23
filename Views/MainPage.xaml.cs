namespace LetsPlayDiscgolfMaui;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void GoToMyBag_Clicked(object sender, EventArgs e)
    {

    }

    private async void GoToGamesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ChooseGamePage());
    }
}

