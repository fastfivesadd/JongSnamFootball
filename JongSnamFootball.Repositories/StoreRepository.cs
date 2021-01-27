﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JongSnamFootball.Repositories
{
    public class StoreRepository : BaseRepository<StoreModel>, IStoreRepository
    {
        public StoreRepository(ILogger<StoreRepository> logger, RepoDbContext context) : base(logger, context)
        {

        }

        public async Task<List<StoreModel>> GetAll()
        {
            var result = await _dbContext.Store.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<List<StoreModel>> GetByOwnerId(int? ownerId)
        {
            if (ownerId.HasValue)
            {
                return await _dbContext.Store.Where(w => w.Owner == ownerId).AsNoTracking().ToListAsync();
            }

            return new List<StoreModel>();
        }

        public async Task<StoreModel> GetCommentByStoreId(int? storeID)
        {
            if (storeID.HasValue)
            {
                return await _dbContext.Store.Where(w => w.Id == storeID).Include(i => i.CommentModel).AsNoTracking().FirstOrDefaultAsync();
            }

            return new StoreModel();
        }
    }
}
