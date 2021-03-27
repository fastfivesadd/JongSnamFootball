using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IAuthenticationManager
    {
        Task<bool> Login(string user, string password);

        Task<bool> Logout(int id);

        Task<bool> CheckIsLoggedIn(string user, string password);
    }
}
