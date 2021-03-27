using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IAuthenticationManager
    {
        Task<UserDto> Login(string user, string password);

        Task<bool> Logout(int id);

        Task<bool> CheckIsLoggedIn(string user, string password);
    }
}
