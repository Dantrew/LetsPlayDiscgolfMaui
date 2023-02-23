using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Interface
{
    internal interface IGame
    {
        internal int NumberOfPlayers { get; set; }
        internal int Points { get; set; }
        internal int Throws { get; set; }
        internal int Holes { get; set; }
    }
}
