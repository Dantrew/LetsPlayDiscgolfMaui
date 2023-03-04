using LetsPlayDiscgolfMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Interface
{
    internal interface IGameInfo
    {
        internal string PlayerName { get; set; }
        internal int? Points { get; set; }
        internal int Throws { get; set; }
    }
}
