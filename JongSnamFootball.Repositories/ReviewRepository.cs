using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewModel>, IReviewRepository
    {
        public ReviewRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<ReviewModel>> GetAll()
        {
            var result = await _dbContext.Reviews.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<ReviewModel>> GetReviewByStoreId(int storeID)
        {
            return await _dbContext.Reviews.Where(w => w.StoreId == storeID)
                .Include(i => i.UserModel)
                .Include(i => i.StoreModel)
                .AsNoTracking().ToListAsync();
        }
    }
}
