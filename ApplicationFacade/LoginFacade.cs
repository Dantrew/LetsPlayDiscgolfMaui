using LetsPlayDiscgolfMaui.Facade;
using LetsPlayDiscgolfMaui.Facade.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ApplicationFacade
{
    internal class LoginFacade : ILoginFacade
    {
    private readonly IAuthenticationService _authenticationService;


        // ------------------------------- Facade is used to check if user are vaild.
        // ------------------------------- I find facade to be useful so I just can call on the facade to check if the user exist
        // ------------------------------- and match with the users password. 
        public LoginFacade()
        {
            _authenticationService = new AuthenticationService();
        }
        public bool CanLogIn(string userName, string password)
        {
            if (_authenticationService.IsAuthenticated(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
