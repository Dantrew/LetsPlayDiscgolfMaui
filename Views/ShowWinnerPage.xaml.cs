namespace LetsPlayDiscgolfMaui.Views;

public partial class ShowWinnerPage : ContentPage
{
    ViewModels.ShowWinnerPageViewModel vm = new ViewModels.ShowWinnerPageViewModel();
    public ShowWinnerPage()
    {
        InitializeComponent();
        BindingContext = vm;
        ShowSkinsPage();
        ShowBackButton();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void ShowSkinsPage()
    {
        if(ChooseGamePage.chooseGame == "GameSkins")
        {
            _showThrowsList.IsVisible = false;
            _showValueList.IsVisible = true;
        }
    }
    private async void ShowBackButton()
    {
        if(ChooseGamePage.chooseGame == "GameTimed")
        {
            _backButton.IsVisible = false;
        }
    }

    private async void OnEndRoundClicked(object sender, EventArgs e)
    {
        var existingPages = Navigation.NavigationStack.ToList();
        for (int i = 1; i < existingPages.Count - 1; i++)
        {

            Navigation.RemovePage(existingPages[i]);
        }
        if (MainPage.loggedIn == true)
        {
            await vm.RoundsRegister(vm.GameInfos.ToList());
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
        else
        {
            await Navigation.PushAsync(new Views.ChooseGamePage());
        }
    }
}