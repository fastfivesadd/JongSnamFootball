using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var result = await _dbContext.Users.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<UserModel> GetPasswordByEmail(string email)
        {
            return await _dbContext.Users.Where(w => w.Email == email).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
