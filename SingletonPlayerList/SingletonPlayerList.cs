using LetsPlayDiscgolfMaui.Interface;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Sessiondata
{
    internal class SingletonPlayerList
    {
        List<GameInfo> playerList = new();
        User user = new User();

        private static readonly SingletonPlayerList _instance = new SingletonPlayerList();
        public SingletonPlayerList()
        {

        }

        public void LoggedInUser(string name)
        {
            user.Name = name;
        }
        public string GetLoggedInUser()
        {
            return user.Name;
        }

        public static SingletonPlayerList GetPlayerList()
        {
            return _instance;
        }

        public Command<GameInfo> RemovePlayer
        {
            get
            {
                return new Command<GameInfo>((GameInfo) =>
                {
                    playerList.Remove(GameInfo);
                });
            }
        }

        public void ClearListOfPlayers()
        {
            playerList.Clear();
        }

        public void ReturnPlayerFromList(ObservableCollection<GameInfo> fillPlayers)
        {
            if (ChooseGamePage.chooseGame == "GameSkins")
            {
                ConvertValuePerHolesToString(fillPlayers);
            }
            else
            {
                ConvertThrowsPerHolesToString(fillPlayers);
            }
            foreach (var player in playerList)
            {
                fillPlayers.Add(player);
            }
        }

        public void ConvertThrowsPerHolesToString(ObservableCollection<GameInfo> convertToString)
        {
            foreach (var p in playerList)
            {
                p.ThrowsPerRound = string.Empty;
                for (int i = 0; i < p.ThrowsPerHole.Length; i++)
                {
                    p.ThrowsPerRound += p.ThrowsPerHole[i].ToString() + " ";
                }
            }
        }

        public void ConvertValuePerHolesToString(ObservableCollection<GameInfo> convertToString)
        {
            foreach (var p in playerList)
            {
                p.ThrowsPerRound = string.Empty;
                for (int i = 0; i < p.ValuePerHole.Length; i++)
                {
                    p.ThrowsPerRound += p.ValuePerHole[i].ToString() + " ";
                }
            }
        }

        public void FillPlayersToSessionData(ObservableCollection<GameInfo> gameInfos)
        {

            foreach (var g in gameInfos)
            {
                playerList.Add(g);
            }
        }
    }
}
