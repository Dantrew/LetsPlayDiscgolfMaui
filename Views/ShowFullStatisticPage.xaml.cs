namespace LetsPlayDiscgolfMaui.Views;

public partial class ShowFullStatisticPage : ContentPage
{
    ViewModels.ShowFullStatisticPageViewModel vm = new ViewModels.ShowFullStatisticPageViewModel();
    public ShowFullStatisticPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}