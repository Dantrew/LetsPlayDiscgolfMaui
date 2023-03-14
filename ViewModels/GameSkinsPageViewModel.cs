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
    internal partial class GameSkinsPageViewModel : ObservableObject
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
        int skinsTotal = ChooseNumberOfPlayersPage.skinsValue * ChooseNumberOfPlayersPage.chooseNumberOfHoles;

        [ObservableProperty]
        Dictionary<int, int> skinValuePerHole = new();

        public GameSkinsPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            getPlayers.ReturnPlayerFromList(GameInfos);
        }

        public void CalculateSkinsValue(ObservableCollection<GameInfo> gameInfos)
        {

            int[] comparePlayerThrow = new int[gameInfos.Count];
            int i = 0;
            foreach (var g in gameInfos)
            {
                comparePlayerThrow[i] = g.Throws;
                i++;
            }

            var sortedTimeWithMaintainIndex = comparePlayerThrow.Select((x, i) => new KeyValuePair<int, int>(x, i))
            .OrderBy(x => x.Key)
            .ToList();


            int j = 0;
            int compareToPlayerBefore = 0;
            foreach (var sorted in sortedTimeWithMaintainIndex)
            {
                if (j == 0)
                {
                    compareToPlayerBefore = sorted.Key;
                    SkinValuePerHole.Add(sorted.Value, sorted.Key);
                }

                if (j > 0 && sorted.Key == compareToPlayerBefore)
                {
                    SkinValuePerHole.Add(sorted.Value, sorted.Key);
                }
                j++;
            }

            int giveSkinsValue = 0;
            if (SkinValuePerHole.Count > 1)
            {
                giveSkinsValue = ChooseNumberOfPlayersPage.skinsValue / SkinValuePerHole.Count;
            }
            else
            {
                giveSkinsValue = ChooseNumberOfPlayersPage.skinsValue;
            }

            foreach (var s in SkinValuePerHole)
            {
                int k = 0;
                foreach (var g in gameInfos)
                {
                    if (s.Key == k)
                    {
                        gameInfos[k].ValuePerHole[ChooseNumberOfPlayersPage.countHoles] = giveSkinsValue;
                    }
                    k++;
                }
            }
            SkinValuePerHole.Clear();
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
                    game.Points += game.ValuePerHole[i];
                }
            }
        }
    }
}
