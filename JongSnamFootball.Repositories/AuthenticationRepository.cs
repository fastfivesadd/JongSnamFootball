using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class AuthenticationRepository : BaseRepository<UserModel>, IAuthenticationRepository
    {
        public AuthenticationRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<UserModel> GetUser(string user, string passwordEncrypted)
        {
            var result = await _dbContext.Users.Where(w => w.Email == user && w.Password == passwordEncrypted).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }
    }
}
