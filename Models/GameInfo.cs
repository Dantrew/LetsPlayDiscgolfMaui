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
        public string PlayerName { get; set; }
        public int? Points { get; set; } = 0;
        public int? Throws { get; set; }
        public int[] ThrowsPerHole { get; set; }

    }
}
