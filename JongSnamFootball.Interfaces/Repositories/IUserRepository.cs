using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserMemberModel>
    {
        Task<List<UserMemberModel>> GetAllUser();

        Task<UserMemberModel> GetUserById(int id);
    }
}
