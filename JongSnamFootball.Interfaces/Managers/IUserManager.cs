using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.RequestModel;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<List<UserDto>> GetAll();

        Task<bool> CreateUser(UserRequestDto requestDto);
    }
}
