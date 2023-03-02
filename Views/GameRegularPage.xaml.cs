using LetsPlayDiscgolfMaui.Models;
using Microsoft.Maui.Controls.Xaml;
using System.Reflection;


namespace LetsPlayDiscgolfMaui.Views;

public partial class GameRegularPage : ContentPage
{
    ViewModels.GameRegularPageViewModel vm = new ViewModels.GameRegularPageViewModel();
    bool pageStarted = false;
    bool pageBack = false;
    bool pageForward = false;
    int minusThrow = 0;
    public GameRegularPage()
    {

        InitializeComponent();
        BindingContext = vm;
        _whichHole.Text = $"Hole number {Sessiondata.SessionData.CountHoles}";
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
        if (Sessiondata.SessionData.CountHoles == Sessiondata.SessionData.NumberOfHoles)
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());

        }
        else
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());
            Sessiondata.SessionData.CountHoles++;
            await Navigation.PushAsync(new Views.GameRegularPage());


        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        Sessiondata.SessionData.CountHoles--;
        if (Sessiondata.SessionData.CountHoles == 0)
        {
            Sessiondata.SessionData.CountHoles = 1;
        }
        else if (!pageBack)
        {
            ResetThrowsAndAddScore(vm.GameInfos.ToList());
            pageBack = true;
        }
    }
}