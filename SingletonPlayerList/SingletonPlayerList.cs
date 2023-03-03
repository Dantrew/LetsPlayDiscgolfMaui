using LetsPlayDiscgolfMaui.Interface;
using LetsPlayDiscgolfMaui.Models;
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

        private static readonly SingletonPlayerList _instance = new SingletonPlayerList();
        public SingletonPlayerList()
        {
            
        }

        public static SingletonPlayerList GetPlayerList()
        {
            return _instance;
        }

        public Command<GameInfo> RemovePlayer
        {
            get
            {
                return new Command<GameInfo>((GameInfo) => {
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
            foreach (var player in playerList) 
            { 
                fillPlayers.Add(player);
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
