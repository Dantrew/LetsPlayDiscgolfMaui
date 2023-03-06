using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal partial class GameRegularPageViewModel : ObservableObject
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

        public GameRegularPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            getPlayers.ReturnPlayerFromList(GameInfos);
        }

        public void SetThrow(List<GameInfo> GameInfos)
        {

            foreach (var game in GameInfos)
            {
                if (Views.ChooseNumberOfPlayersPage.countHoles < game.ThrowsPerHole.Length)
                    game.Throws = game.ThrowsPerHole[Views.ChooseNumberOfPlayersPage.countHoles];
            }
        }

        public void ResetThrowsAndAddScore(List<GameInfo> GameInfos)
        {

            foreach (var game in GameInfos)
            {
                game.ThrowsPerHole[Views.ChooseNumberOfPlayersPage.countHoles] = game.Throws;
                game.Points = 0;
                for (int i = 0; i < game.ThrowsPerHole.Length; i++)
                {
                    game.Points += game.ThrowsPerHole[i];
                }


            }
        }
    }
}
