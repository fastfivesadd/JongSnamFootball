using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class FieldRepository : BaseRepository<FieldModel>, IFieldRepository
    {
        public FieldRepository(RepositoryDbContext context) : base(context)
        {
        }
        public async Task<List<FieldModel>> GetAll()
        {
            var result = await _dbContext.Fields.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<FieldModel>> GetByStoreId(int? storeId)
        {
            return await _dbContext.Fields.Where(w => w.StoreId == storeId).Include(i => i.StoreModel).AsNoTracking().ToListAsync();
        }

        public async Task<FieldModel> GetFieldById(int id)
        {
                return await _dbContext.Fields.Where(w => w.Id == id)
                    .Include(i => i.ImageField)
                    .Include(i => i.DiscountModel)
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
