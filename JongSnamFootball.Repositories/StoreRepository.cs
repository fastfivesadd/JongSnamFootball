using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class StoreRepository : BaseRepository<StoreModel>, IStoreRepository
    {
        public StoreRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<StoreModel>> GetAll()
        {
            var result = await _dbContext.Store.AsNoTracking().ToListAsync();

            return result;
        }
        public async Task<StoreModel> GetStoreById(int? Id)
        {
            return await _dbContext.Store.Where(w => w.Id == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<StoreModel>> GetStoreByOwnerId(int? ownerId)
        {
            if (ownerId.HasValue)
            {
                return await _dbContext.Store.Where(w => w.Owner == ownerId).AsNoTracking().ToListAsync();
            }

            return new List<StoreModel>();
        }


    }
}
