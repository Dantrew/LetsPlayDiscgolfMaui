using CommunityToolkit.Mvvm.ComponentModel;
using LetsPlayDiscgolfMaui.Database;
using LetsPlayDiscgolfMaui.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal class RegisterPageViewModel : ObservableObject
    {

        public async Task UserRegistration(string userName, string password, string email, string name)
        {
            var myCollection = await DataBase.GetCollection();
            User user = new() { UserName = userName, Password = password, Email = email, Name = name, Id = new Guid(), };
            Task savePlayer = Database.DataBase.SavePlayer(user, myCollection);
        }
        public async Task<string> UserName(string userName)
        {
            var myCollection = await DataBase.GetCollection();

            Task<User> getUserName = DataBase.CheckUserName(myCollection, userName);
            if (getUserName.Result != null)
            {
                if (userName.ToLower() == getUserName.Result.UserName.ToLower())
                {
                    userName = "That username is already taken";
                }
            }
            else
            {
                return userName;
            }
            return userName;

        }
        public async Task<string> Mail(string email)
        {
            var myCollection = await DataBase.GetCollection();
            Regex regexMail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Task<User> checkUserMail = DataBase.CheckUserEmail(myCollection, email);

            if (!regexMail.IsMatch(email))
            {
                email = "Thats not a correct email";
            }
            else if (checkUserMail.Result != null)
            {
                if (email.ToLower() == checkUserMail.Result.Email.ToLower())
                {
                    email = "That email is already taken";
                }
            }
            return email;
        }
    }
}
