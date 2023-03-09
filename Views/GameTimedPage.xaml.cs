using LetsPlayDiscgolfMaui.Sessiondata;
using System.Diagnostics;

namespace LetsPlayDiscgolfMaui.Views;

public partial class GameTimedPage : ContentPage
{
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    ViewModels.GameTimedPageViewModel vm = new ViewModels.GameTimedPageViewModel();
    Stopwatch sw = new Stopwatch();
    private bool clickedStopWatch = false;
    private int count = 0;
    string[] time;
    public GameTimedPage()
    {
        InitializeComponent();
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles + 1}";
        BindingContext = vm;
        SetButtons();
        vm.SetThrow(vm.GameInfos.ToList());
        time = new string[vm.GameInfos.Count];
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            vm.CalculateTotalScore();
            await Navigation.PushAsync(new Views.ShowWinnerPage());
        }
        else
        {
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            ChooseNumberOfPlayersPage.countHoles++;
            await Navigation.PushAsync(new Views.GameTimedPage());
        }
    }

    public void SetButtons()
    {
        if (ChooseNumberOfPlayersPage.countHoles > 0)
        {
            _backButton.IsVisible = false;
        }
        if(ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            _goToNextHole.Text = "Finish round";
        }
    }

    private async void ShowPlayerName()
    {
        _playerName.Text = vm.PlayerName;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        if (ChooseNumberOfPlayersPage.countHoles != 0)
        {
            ChooseNumberOfPlayersPage.countHoles--;
            vm.SetThrowOnBackClicked(vm.GameInfos.ToList());
        }
        else if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            getPlayers.ClearListOfPlayers();
            vm.GameInfos.Clear();
        }
    }

    private async void OnGetPlayerClicked(object sender, EventArgs e)
    {
        if (count == vm.GameInfos.Count)
        {
            sw.Reset();
            _showTimer.Text = "Time complete";
            vm.CalculateTimeScore(time, vm.GameInfos.ToList());
            return;
        }
        if (count < vm.GameInfos.Count)
        {
            if (_getPlayer.Text == "Done")
            {
                _getPlayer.Text = "Get player";
                sw.Reset();
                _showTimer.Text = sw.Elapsed.ToString("mm\\:ss\\:ff");
                return;
            }
            if (!clickedStopWatch)
            {
                _playerName.Text = vm.GameInfos[count].PlayerName;
                _getPlayer.Text = "Start timer";
                clickedStopWatch = true;
                return;
            }

            if (clickedStopWatch)
            {
                if (!sw.IsRunning)
                {
                    sw.Start();
                    _getPlayer.Text = "Stop timer";
                    while (clickedStopWatch)
                    {
                        _showTimer.Text = sw.Elapsed.ToString("mm\\:ss\\:ff");
                        await Task.Delay(1);
                    }
                }
                else
                {
                    sw.Stop();
                    _showTimer.Text = sw.Elapsed.ToString("mm\\:ss\\:ff");
                    _getPlayer.Text = "Done";
                    time[count] = sw.Elapsed.ToString("mm\\:ss\\:ff");
                    count++;
                    clickedStopWatch = false;
                }
            }
        }

    }
}