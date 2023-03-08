using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Database;
using LetsPlayDiscgolfMaui.Interface;
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
        public async Task RoundsRegister(List<GameInfo> gameInfos)
        {
            DateTime dt = DateTime.Now;
            var myCollection = await DataBase.GetRoundsCollection();
            foreach (var g in gameInfos)
            {
                GameInfo gameInfo = new() { UserName = getPlayers.GetLoggedInUser(), PlayerName = g.PlayerName, Throws = 0, Points = g.Points, City = ChooseGamePage.city, ThrowsPerHole = g.ThrowsPerHole, DateTime = dt.ToString("yyyy-MM-dd"), GameType = ChooseGamePage.chooseGame.Substring(4), Id = new Guid(), };
                Task saveRound = DataBase.SaveRound(gameInfo, myCollection);
            }
        }
    }
}
