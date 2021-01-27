using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JongSnamFootball.Repositories
{
    public class DiscountRepository : BaseRepository<DiscountModel>, IDiscountRepository
    {
        public DiscountRepository(ILogger<DiscountRepository> logger, RepoDbContext context) : base(logger, context)
        {

        }
        public async Task<List<DiscountModel>> GetAll()
        {
            var result = await _dbContext.Discount.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
