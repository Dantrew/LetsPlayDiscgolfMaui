namespace LetsPlayDiscgolfMaui.Views;

public partial class ShowWinnerPage : ContentPage
{
    ViewModels.ShowWinnerPageViewModel vm = new ViewModels.ShowWinnerPageViewModel();
    public ShowWinnerPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnEndRoundClicked(object sender, EventArgs e)
    {
        var existingPages = Navigation.NavigationStack.ToList();
        for(int i = 1; i < existingPages.Count - 1; i++)
        {

            Navigation.RemovePage(existingPages[i]);
        }

        await Navigation.PushAsync(new Views.ChooseGamePage());
    }
}