using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JongSnamFootball.Repositories
{
    public class UserRepository : BaseRepository<UserMemberModel>, IUserRepository
    {
        public UserRepository(ILogger<UserRepository> logger, RepoDbContext context) : base(logger, context)
        {

        }

        public async Task<List<UserMemberModel>> GetAll()
        {
            var result = await _dbContext.Usermember.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
