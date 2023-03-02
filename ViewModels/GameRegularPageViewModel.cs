using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Models;
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
            gameInfos = new ObservableCollection<GameInfo>();
            FillUpList(Sessiondata.SessionData.GameInfos);
        }

        private void FillUpList(List<GameInfo> listIn)
        {
            foreach (var l in listIn)
            {
                GameInfos.Add(l);
            }
        }
    }
}
