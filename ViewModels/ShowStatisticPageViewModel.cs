﻿using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Database;
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
    internal partial class ShowStatisticPageViewModel : ObservableObject
    {
        static SingletonPlayerList getPlayers = SingletonPlayerList.GetPlayerList();
        [ObservableProperty]
        ObservableCollection<GameInfo> gameInfos = new();
        [ObservableProperty]
        string playerName;
        [ObservableProperty]
        int points;
        [ObservableProperty]
        int throws;
        [ObservableProperty]
        string city;
        [ObservableProperty]
        int[] throwsPerHole;
        [ObservableProperty]
        string dateTime;
        [ObservableProperty]
        string gameType;
        [ObservableProperty]
        string throwsPerRound;

        public ShowStatisticPageViewModel()
        {
            _ = GetTopFiveStatistic(gameInfos);
        }

        public async Task<ObservableCollection<GameInfo>> GetTopFiveStatistic(ObservableCollection<GameInfo> statisticList)
        {

            string userName = getPlayers.GetLoggedInUser();
            var myCollection = await DataBase.GetRoundsCollection();
            var dbStatsList = DataBase.GetRoundsPlayed(myCollection, userName);
            foreach (var d in dbStatsList.TakeLast(5))
            {
                for(int i = 0; i < d.ThrowsPerHole.Length; i++)
                {
                    d.ThrowsPerRound += d.ThrowsPerHole[i].ToString() + " ";
                }
                statisticList.Add(d);
            };

            statisticList.OrderByDescending(x => x.DateTime);

            return statisticList;

        }

    }
}
