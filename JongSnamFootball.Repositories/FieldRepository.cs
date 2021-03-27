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

        public async Task<List<FieldModel>> GetFieldBySearch(SearchFieldRequest request)
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

            if (request.DistrictId.HasValue)
            {
                result = result.Where(w => w.StoreModel.DistrictId == request.DistrictId.Value);
            }

            if (request.ProvinceId.HasValue)
            {
                result = result.Where(w => w.StoreModel.ProvinceId == request.ProvinceId.Value);
            }

            return await result.ToListAsync();
        }

        public async Task<List<FieldModel>> GetByStoreId(int? storeId)
        {
            return await _dbContext.Fields.Where(w => w.StoreId == storeId).Include(i => i.StoreModel).Include(i => i.ImageFieldModel).AsNoTracking().ToListAsync();
        }

        public async Task<FieldModel> GetFieldById(int id)
        {
            return await _dbContext.Fields.Where(w => w.Id == id)
                .Include(i => i.ImageFieldModel)
                .Include(i => i.DiscountModel)
                .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
