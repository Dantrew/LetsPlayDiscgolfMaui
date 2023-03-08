using CommunityToolkit.Mvvm.ComponentModel;
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
    internal partial class ShowFullStatisticPageViewModel : ObservableObject
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

        public ShowFullStatisticPageViewModel()
        {
            _ = GetALLStatistic(gameInfos);
        }

        public async Task<ObservableCollection<GameInfo>> GetALLStatistic(ObservableCollection<GameInfo> statisticList)
        {
            string userName = getPlayers.GetLoggedInUser();
            var myCollection = await DataBase.GetRoundsCollection();
            var dbStatsList = DataBase.GetRoundsPlayed(myCollection, userName);
            foreach (var d in dbStatsList)
            {
                statisticList.Add(d);
            };

            return statisticList;

        }
    }
}
