using System.Collections.Generic;
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

        public async Task<List<UserMemberModel>> GetAll()
        {
            var result = await _dbContext.Usermember.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
