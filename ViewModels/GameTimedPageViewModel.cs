using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
using LetsPlayDiscgolfMaui.Views;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

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


        public GameTimedPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            string[] time = new string[gameInfos.Count];
            getPlayers.ReturnPlayerFromList(GameInfos);
            CalculateTotalScore();
        }
        public void CalculateTimeScore(string[] time, List<GameInfo> gameInfos)
        {
            int[] compareTime = new int[gameInfos.Count];
            for (int i = 0; i < time.Length; i++)
            {
                var modifiedTime = string.Join("", time[i].Split(':'));
                compareTime[i] = Convert.ToInt32(modifiedTime);
            }
            var sortedTimeWithMaintainIndex = compareTime.Select((x, i) => new KeyValuePair<int, int>(x, i))
            .OrderBy(x => x.Key)
            .ToList();

            int j = 0;
            foreach (var sorted in sortedTimeWithMaintainIndex)
            {
                for (int i = 0; i < gameInfos.Count; i++)
                {
                    if (sortedTimeWithMaintainIndex[j].Value == i)
                    {
                        gameInfos[i].ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles] += sortedTimeWithMaintainIndex.Count - 1 - j;
                    }
                }
                j++;
            }
        }
        public void SetThrow(List<GameInfo> GameInfos)
        {
            foreach (var game in GameInfos)
            {
                if (Views.ChooseNumberOfPlayersPage.countHoles < game.ThrowsPerHole.Length)
                {
                    if (game.ThrowsPerHole[Views.ChooseNumberOfPlayersPage.countHoles] != 10)
                    {
                        game.Throws = 10 - game.ThrowsPerHole[Views.ChooseNumberOfPlayersPage.countHoles];
                    }
                    else
                    {
                        game.Throws = 0;
                    }
                }
            }
        }

        public void CalculateTotalScore()
        {
            if (ChooseNumberOfPlayersPage.countHoles == 0)
            {
                foreach (var game in GameInfos)
                {
                    game.Points = 0;
                    for (var i = 0; i < game.ThrowsPerHole.Length; i++)
                    {
                        game.ThrowsPerHole[i] = 10;
                        game.Points += 10;
                    }
                }
            }
            else
            {
                foreach (var game in GameInfos)
                {
                    game.Points = 0;
                    for (var i = 0; i < game.ThrowsPerHole.Length; i++)
                    {
                        game.Points += game.ThrowsPerHole[i];

                    }
                }
            }
        }

        public void SetThrowOnBackClicked(List<GameInfo> GameInfos)
        {
            foreach (var game in GameInfos)
            {
                game.Throws = 10 - game.ThrowsPerHole[ChooseNumberOfPlayersPage.countHoles];

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

            }
        }
    }
}
