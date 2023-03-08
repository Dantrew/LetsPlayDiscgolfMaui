using LetsPlayDiscgolfMaui.Sessiondata;
using System.Diagnostics;

namespace LetsPlayDiscgolfMaui.Views;

public partial class GameTimedPage : ContentPage
{
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    ViewModels.GameTimedPageViewModel vm = new ViewModels.GameTimedPageViewModel();
    Stopwatch sw = new Stopwatch();
    public GameTimedPage()
    {
        InitializeComponent();
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles + 1}";
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            await Navigation.PushAsync(new Views.ShowWinnerPage());
        }
        else
        {
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            ChooseNumberOfPlayersPage.countHoles++;
            await Navigation.PushAsync(new Views.GameTimedPage());
        }
    }
    private async void OnOneTimerClicked(object sender, EventArgs e)
    {
        if (sw.IsRunning == false)
        {
            sw.Start();
            while (true)
            {
                ShowTimer.Text = sw.Elapsed.ToString("mm\\:ss\\:ff");
                await Task.Delay(1);
            }
        }
        else
        {
            sw.Stop();
            ShowTimer.Text = sw.Elapsed.ToString("mm\\:ss\\:ff");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        if (ChooseNumberOfPlayersPage.countHoles != 0)
        {
            ChooseNumberOfPlayersPage.countHoles--;
            vm.SetThrow(vm.GameInfos.ToList());
        }
        else if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            getPlayers.ClearListOfPlayers();
            vm.GameInfos.Clear();
        }
    }
}