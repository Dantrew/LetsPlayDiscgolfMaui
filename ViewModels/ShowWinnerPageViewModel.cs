using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Interface;
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
    internal partial class ShowWinnerPageViewModel : ObservableObject
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
        public int[] throwsPerHole;

        public ShowWinnerPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            getPlayers.ReturnPlayerFromList(GameInfos);
        }
    }
}
