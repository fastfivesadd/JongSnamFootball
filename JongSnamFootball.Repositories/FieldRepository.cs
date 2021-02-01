using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class FieldRepository : BaseRepository<FieldModel>, IFieldRepository
    {
        public FieldRepository(RepositoryDbContext context) : base(context)
        {
        }

        public async Task<List<FieldModel>> GetAll(SearchFieldRequest request)
        {
            var result = _dbContext.Fields.Include(i => i.StoreModel).AsNoTracking();

            if (request.StartPrice.HasValue)
            {
                result = result.Where(w => w.Price >= request.StartPrice);
            }

            if (request.ToPrice.HasValue)
            {
                result = result.Where(w => w.Price <= request.ToPrice);
            }

            if (!string.IsNullOrWhiteSpace(request.Amphur))
            {
                result = result.Where(w => w.StoreModel.Amphur.Contains(request.Amphur));
            }

            if (!string.IsNullOrWhiteSpace(request.Province))
            {
                result = result.Where(w => w.StoreModel.Province.Contains(request.Province));
            }

            return await result.ToListAsync();
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
