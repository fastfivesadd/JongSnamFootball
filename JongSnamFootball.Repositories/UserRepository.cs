using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class UserRepository : BaseRepository<UserMemberModel>, IUserRepository
    {
        public UserRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<UserMemberModel>> GetAllUser()
        {
            var result = await _dbContext.Usermember.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<UserMemberModel> GetUserById(int id)
        {
            return await _dbContext.Usermember.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
