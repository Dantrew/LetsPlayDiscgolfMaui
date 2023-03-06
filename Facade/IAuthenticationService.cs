using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Facade
{
    internal interface IAuthenticationService
    {
        bool IsAuthenticated(string userName, string passWord);
    }
}
