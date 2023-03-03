using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using Microsoft.Maui.Controls.Xaml;
using System.Reflection;


namespace LetsPlayDiscgolfMaui.Views;

public partial class GameRegularPage : ContentPage
{
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    ViewModels.GameRegularPageViewModel vm = new ViewModels.GameRegularPageViewModel();
    bool pageStarted = false;
    bool pageBack = false;
    bool pageForward = false;
    int minusThrow = 0;
    public GameRegularPage()
    {

        InitializeComponent();
        BindingContext = vm;
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles}";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            pageStarted = true;
        }
    }

    private void ResetThrowsAndAddScore(List<GameInfo> gameInfos)
    {
        foreach (var g in gameInfos)
        {

            if (g.Points == null)
            {
                g.Points = 0;
            }
            if (pageBack)
            {
                g.Points -= minusThrow;
                g.Throws = 0;
            }
            else
            {
                minusThrow = (int)g.Throws;
                g.Points += g.Throws;
                g.Throws = 0;
            }


        }
    }
    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles)
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());

        }
        else
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());
            ChooseNumberOfPlayersPage.countHoles++;
            await Navigation.PushAsync(new Views.GameRegularPage());


        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        getPlayers.ClearListOfPlayers();
        await Navigation.PopAsync();
        ChooseNumberOfPlayersPage.countHoles--;
        if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            ChooseNumberOfPlayersPage.countHoles = 1;
        }
        else if (!pageBack)
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());
            pageBack = true;
        }
    }
}