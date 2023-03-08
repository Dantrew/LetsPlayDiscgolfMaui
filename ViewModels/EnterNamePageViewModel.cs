using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetsPlayDiscgolfMaui.Models;
using LetsPlayDiscgolfMaui.Sessiondata;
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
        [ObservableProperty]
        int[] throwsPerHole;

        public AddNamePageViewModel()
        {
            GameInfos = new ObservableCollection<GameInfo>();
            ChooseNumberOfPlayersPage.countHoles = 0;


        }

        [RelayCommand]
        public async void AddPlayer()
        {
            if (GameInfos.Count < ChooseNumberOfPlayersPage.chooseNumberOfPlayers)
            {
                ThrowsPerHole = new int[ChooseNumberOfPlayersPage.chooseNumberOfHoles];

                for (int i = 0; i < ThrowsPerHole.Length; i++)
                {
                    ThrowsPerHole[i] = 0;
                };
                GameInfos.Add(
                    new GameInfo
                    {
                        PlayerName = PlayerName,
                        ThrowsPerHole = ThrowsPerHole
                    }
                    );              
            }
            else 
            {
                
            }
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

       

    }
}
