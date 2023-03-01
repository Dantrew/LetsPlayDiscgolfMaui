using LetsPlayDiscgolfMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Sessiondata
{
    internal static class SessionData
    {
        public static List<GameInfo> gameInfos = new List<GameInfo>();
        public static string PlayerOnePoints { get; set; }
        public static string PlayerTwoPoints { get; set; }
        public static string PlayerThreePoints { get; set; }
        public static string PlayerFourPoints { get; set; }
        public static string PlayerFivePoints { get; set; }
        public static string PlayerSixPoints { get; set; }
        public static string PlayerSevenPoints { get; set; }
        public static string PlayerEightPoints { get; set; }
        public static string PlayerNinePoints { get; set; }
        public static string PlayerTenPoints { get; set; }
        public static string GameType { get; set;}
        public static int NumberOfPlayers { get; set;}
        public static int NumberOfHoles { get; set; }

    }
}
