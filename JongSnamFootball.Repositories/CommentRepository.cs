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
    public class CommentRepository : BaseRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<CommentModel>> GetAll()
        {
            var result = await _dbContext.Comment.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<CommentModel>> GetCommentByStoreId(int storeID)
        {
            return await _dbContext.Comment.Where(w => w.StoreId == storeID)
                .Include(i => i.UserModel)
                .Include(i => i.StoreModel)
                .AsNoTracking().ToListAsync();
        }
    }
}
