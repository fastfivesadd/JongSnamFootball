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
    public class FieldRepository : BaseRepository<FieldModel>, IFieldRepository
    {
        public FieldRepository(ILogger<FieldRepository> logger, RepoDbContext context) : base(logger, context)
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
                return await _dbContext.Field.Where(w => w.IdStore == storeID).AsNoTracking().ToListAsync();
            }

            return new List<FieldModel>();
        }

        public async Task<List<FieldModel>> GetByFieldID(int? fieldID)
        {
            if (fieldID.HasValue)
            {
                return await _dbContext.Field.Where(w => w.Id == fieldID).AsNoTracking().ToListAsync();
            }

            return new List<FieldModel>();
        }
    }
}
