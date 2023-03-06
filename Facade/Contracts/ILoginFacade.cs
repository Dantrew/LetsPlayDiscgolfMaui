using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Facade.Contracts
{
    internal interface ILoginFacade
    {
        bool CanLogIn(string userName, string password);
    }
}
