using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using LetsPlayDiscgolfMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    partial class GameTimedPageViewModel : ObservableObject
    {
        static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();

        [ObservableProperty]
        ObservableCollection<GameInfo> gameInfos;
        [ObservableProperty]
        string playerName;
        [ObservableProperty]
        int points;
        [ObservableProperty]
        int throws;
        [ObservableProperty]
        string[] time;


        public GameTimedPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            getPlayers.ReturnPlayerFromList(GameInfos);
            GiveStartPoints();
        }

        public void SetThrow(List<GameInfo> GameInfos)
        {

            foreach (var game in GameInfos)
            {
                if (Views.ChooseNumberOfPlayersPage.countHoles < game.ThrowsPerHole.Length)
                    game.Throws = game.ThrowsPerHole[Views.ChooseNumberOfPlayersPage.countHoles];
            }
        }

        public void GiveStartPoints()
        {
            if (ChooseNumberOfPlayersPage.countHoles == 0)
            {
                foreach (var game in GameInfos)
                {
                    for (var i = 0; i < game.ThrowsPerHole.Length; i++)
                    {
                        game.ThrowsPerHole[i] = 10;
                        game.Points += 10;
                    }
                }
            }
        }

        public void ResetThrowsAndAddScore(List<GameInfo> GameInfos)
        {

            foreach (var game in GameInfos)
            {
                if (game.Throws < 10)
                {
                    game.ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles] -= game.Throws;
                }
                else
                {
                    game.ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles] = 0;
                }
                for (int i = 0; i < game.ThrowsPerHole.Length; i++)
                {
                    game.Points -= game.ThrowsPerHole[i];
                }


            }
        }
    }
}
