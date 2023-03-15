using LetsPlayDiscgolfMaui.Sessiondata;

namespace LetsPlayDiscgolfMaui.Views;

public partial class GameSkinsPage : ContentPage
{
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    ViewModels.GameSkinsPageViewModel vm = new ViewModels.GameSkinsPageViewModel();
    public GameSkinsPage()
	{
		InitializeComponent();
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles + 1}";
        InformationSkinsValue();
        NextHoleButtonInfo();
        BindingContext = vm;
        vm.SetThrow(vm.GameInfos.ToList());
    }

    private async void InformationSkinsValue()
    {
        if (ChooseNumberOfPlayersPage.countHoles == 0)
            _eachPlayerPay.Text = $"Each player pays {vm.SkinsTotal / ChooseNumberOfPlayersPage.chooseNumberOfPlayers} " +
                $"\nfor a total of course value: {vm.SkinsTotal}";
        else
        {
            _eachPlayerPay.IsVisible = false;
        }
    }

    private void NextHoleButtonInfo()
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            _buttonNextHole.Text = "End round";
        }
        else
        {
            _buttonNextHole.Text = "Next hole";
        }
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        if (ChooseNumberOfPlayersPage.countHoles != 0)
        {
            ChooseNumberOfPlayersPage.countHoles--;
            vm.SkinValuePerHole.Clear();
            vm.SetThrow(vm.GameInfos.ToList());
        }
        else if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            getPlayers.ClearListOfPlayers();
            vm.SkinValuePerHole.Clear();
            vm.GameInfos.Clear();
        }
    }

    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            vm.CalculateSkinsValue(vm.GameInfos);
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            await Navigation.PushAsync(new Views.ShowWinnerPage());
        }
        else
        {
            vm.CalculateSkinsValue(vm.GameInfos);
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            ChooseNumberOfPlayersPage.countHoles++;
            await Navigation.PushAsync(new Views.GameSkinsPage());
        }
    }
}