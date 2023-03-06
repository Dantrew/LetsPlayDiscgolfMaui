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

    public GameRegularPage()
    {

        InitializeComponent();
        BindingContext = vm;
        _whichHole.Text = $"Hole number {ChooseNumberOfPlayersPage.countHoles + 1}";
        vm.SetThrow(vm.GameInfos.ToList());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void GoToNextHole(object sender, EventArgs e)
    {
        if (ChooseNumberOfPlayersPage.countHoles == ChooseNumberOfPlayersPage.chooseNumberOfHoles - 1)
        {
            //vm.SetThrow(vm.GameInfos.ToList());
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
            await Navigation.PushAsync(new Views.ShowWinnerPage());
        }
        else
        {
            vm.ResetThrowsAndAddScore(vm.GameInfos.ToList());
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
            vm.SetThrow(vm.GameInfos.ToList());
        }
        else if (ChooseNumberOfPlayersPage.countHoles == 0)
        {
            getPlayers.ClearListOfPlayers();
            vm.GameInfos.Clear();
        }
    }
}