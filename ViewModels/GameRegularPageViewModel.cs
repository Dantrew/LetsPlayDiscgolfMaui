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
        //[ObservableProperty]
        //Stack<int> holeStatistic;
        public GameRegularPageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            getPlayers.ReturnPlayerFromList(GameInfos);
        }
    }
}
