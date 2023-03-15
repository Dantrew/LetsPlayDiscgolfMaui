using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Models
{
    internal class GameInfo : IGameInfo
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string PlayerName { get; set; }
        public int? Points { get; set; } = 0;
        public int Throws { get; set; }
        public string? City { get; set; }
        public int[] ThrowsPerHole { get; set; }
        public int[] ValuePerHole { get; set; }
        public string DateTime { get; set; }
        public string GameType { get; set; }
        public string? ThrowsPerRound { get; set; }

    }
}
