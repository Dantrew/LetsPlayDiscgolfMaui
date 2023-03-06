using LetsPlayDiscgolfMaui.Database;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Facade
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated(string userName, string passWord)
        {
            var player = CheckDataBase(userName, passWord);
            if (player.Result != null)
            {
                return true;
            }
            return false;
        }

        internal static async Task<Models.User> CheckDataBase(string userName, string passWord)
        {

            var myCollection = await DataBase.GetCollection();
            var login = DataBase.CompareUserNameToPassword(myCollection, userName, passWord);

            return login;
        }
    }
}
