using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.ViewModels;
using System.Diagnostics;

namespace LetsPlayDiscgolfMaui.Views;

public partial class EnterNamePage : ContentPage
{
    ViewModels.AddNamePageViewModel vm = new ViewModels.AddNamePageViewModel();
    public EnterNamePage()
    {
        InitializeComponent();
        BindingContext = vm;
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

        if (vm.GameInfos.Count == Sessiondata.SessionData.NumberOfPlayers)
        {

            if (Sessiondata.SessionData.GameType == "GameTimedPage")
            {
                await Navigation.PushAsync(new Views.GameTimedPage());
            }
            else if (Sessiondata.SessionData.GameType == "GameSkinsPage")
            {
                await Navigation.PushAsync(new Views.GameSkinsPage());
            }
            else if (Sessiondata.SessionData.GameType == "GameChallengePage")
            {
                await Navigation.PushAsync(new Views.GameChallengePage());
            }
            else if (Sessiondata.SessionData.GameType == "GameRegularPage")
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
        await Navigation.PopAsync();
        Sessiondata.SessionData.GameInfos.Clear();
    }

    private void RemoveClickedCommand(object sender, EventArgs e)
    {
        var button = sender as Button;
        var removePlayer = button.BindingContext as GameInfo;
        var vm = BindingContext as AddNamePageViewModel;
        vm.RemovePlayer.Execute(removePlayer);
    }
}