using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal partial class AddNamePageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<GameInfo> gameInfos;
        [ObservableProperty]
        string playerName;

        public AddNamePageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
        }

        [RelayCommand]
        public void AddPlayer()
        {
            if (GameInfos.Count < Sessiondata.SessionData.NumberOfPlayers)
            {

                GameInfos.Add(
                    new GameInfo
                    {
                        PlayerName = PlayerName,
                    }
                    );
                FillPlayersToSessionData(GameInfos);
            }
            else 
            {

            }
        }


        public static string  WarningToManyPlayers()
        {
            string s = "Too many players input";
            return s;
        }

        public Command<GameInfo> RemovePlayer
        {
            get
            {
                return new Command<GameInfo>((GameInfo) => {
                   GameInfos.Remove(GameInfo);
                });
            }
        }



        public void FillPlayersToSessionData(ObservableCollection<GameInfo> gameInfos)
        {
            Sessiondata.SessionData.GameInfos.Clear();
            foreach (var g in gameInfos)
            {
                Sessiondata.SessionData.GameInfos.Add(g);
            }
        }

    }
}
