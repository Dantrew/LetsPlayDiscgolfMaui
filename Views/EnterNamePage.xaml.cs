using LetsPlayDiscgolfMaui.Interface;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using LetsPlayDiscgolfMaui.ViewModels;
using System.Diagnostics;

namespace LetsPlayDiscgolfMaui.Views;

public partial class EnterNamePage : ContentPage
{
    ViewModels.AddNamePageViewModel vm = new ViewModels.AddNamePageViewModel();
    static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
    public EnterNamePage()
    {
        InitializeComponent();
        BindingContext = vm;
        getPlayers.ClearListOfPlayers();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ResetWarningText();
    }
    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var players = ((ListView)sender).SelectedItem as Models.GameInfo;
    }

    private void WarningText()
    {
        WarningToManyPlayers.Text = $"List is not filled, add or change number of players.";
    }

    private void ResetWarningText()
    {
        WarningToManyPlayers.Text = $"";
    }
    private async void ChosenGamesClicked(object sender, EventArgs e)
    {

        if (vm.GameInfos.Count == ChooseNumberOfPlayersPage.chooseNumberOfPlayers)
        {
            getPlayers.FillPlayersToSessionData(vm.GameInfos);

            if (ChooseGamePage.chooseGame == "GameTimedPage")
            {
                await Navigation.PushAsync(new Views.GameTimedPage());
            }
            else if (ChooseGamePage.chooseGame == "GameSkinsPage")
            {
                await Navigation.PushAsync(new Views.GameSkinsPage());
            }
            else if (ChooseGamePage.chooseGame == "GameChallengePage")
            {
                await Navigation.PushAsync(new Views.GameChallengePage());
            }
            else if (ChooseGamePage.chooseGame == "GameRegularPage")
            {
                await Navigation.PushAsync(new Views.GameRegularPage());
            }
        }
        else
        {
            WarningText();
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        getPlayers.ClearListOfPlayers();
        await Navigation.PopAsync();
        
    }

    private void RemoveClickedCommand(object sender, EventArgs e)
    {
        var button = sender as Button;
        var removePlayer = button.BindingContext as GameInfo;
        var vm = BindingContext as AddNamePageViewModel;
        vm.RemovePlayer.Execute(removePlayer);
        getPlayers.RemovePlayer.Execute(removePlayer);
    }

    private async void OnAddPlayerClickedSetStringEmpty(object sender, EventArgs e)
    {
        AddName.Text = string.Empty;
    }
}