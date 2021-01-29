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
            var result = await _dbContext.Field.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<FieldModel>> GetByStoreID(int? storeID)
        {
            if (storeID.HasValue)
            {
                return await _dbContext.Field.Where(w => w.IdStore == storeID).Include(i => i.StoreModel).AsNoTracking().ToListAsync();
            }

            return new List<FieldModel>();
        }

        public async Task<FieldModel> GetFieldById(int id)
        {
                return await _dbContext.Field.Where(w => w.Id == id)
                    .Include(i => i.PictureFieldModel)
                    .Include(i => i.DiscountModel)
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
