using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class DiscountRepository : BaseRepository<DiscountModel>, IDiscountRepository
    {
        public DiscountRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<DiscountModel>> GetAll()
        {
            var result = await _dbContext.Discounts.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
