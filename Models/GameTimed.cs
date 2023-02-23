using LetsPlayDiscgolfMaui.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Models
{
    internal class GameTimed : IGame
    {
        public int NumberOfPlayers { get; set; }
        public int Points { get; set; }
        public int Throws { get; set; }
        public int Holes { get; set; }
    }
}
