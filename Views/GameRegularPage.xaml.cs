using LetsPlayDiscgolfMaui.Interface;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using Microsoft.Maui.Controls.Xaml;
using System.Reflection;


namespace LetsPlayDiscgolfMaui.Views;

public partial class GameRegularPage : ContentPage
{
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    ViewModels.GameRegularPageViewModel vm = new ViewModels.GameRegularPageViewModel();
    bool pageForward;

    public GameRegularPage()
    {

        InitializeComponent();
        BindingContext = vm;
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles + 1}";
        SetThrow(vm.GameInfos.ToList());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void SetThrow(List<GameInfo> GameInfos)
    {
        
        foreach (var game in GameInfos)
        {
            if(ChooseNumberOfPlayersPage.countHoles < game.ThrowsPerHole.Length)
            game.Throws = game.ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles];
        }
    }

    private void ResetThrowsAndAddScore(List<GameInfo> GameInfos)
    {

        foreach (var game in GameInfos)
        {  
            game.ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles] = game.Throws;
            game.Points = 0;
            for (int i = 0; i < game.ThrowsPerHole.Length; i++)
            {
                game.Points += game.ThrowsPerHole[i];
            }


        }
    }
    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            await Navigation.PushAsync(new Views.ShowWinnerPage());
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
        await Navigation.PopAsync();
        if (ChooseNumberOfPlayersPage.countHoles != 0)
        {
            ChooseNumberOfPlayersPage.countHoles--;
            SetThrow(vm.GameInfos.ToList());
            //ResetThrowsAndAddScore(vm.GameInfos.ToList());
        }
        else if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            getPlayers.ClearListOfPlayers();
            vm.GameInfos.Clear();
        }
    }
}