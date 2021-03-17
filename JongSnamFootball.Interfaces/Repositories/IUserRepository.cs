using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<List<UserModel>> GetAllUser();

        Task<UserModel> GetUserById(int id);

        Task<UserModel> GetPasswordByEmail(string email);
    }
}
