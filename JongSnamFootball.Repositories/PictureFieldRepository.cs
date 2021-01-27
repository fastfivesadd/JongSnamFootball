using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    class PictureFieldRepository : BaseRepository<PictureFieldModel>, IPictureFieldRepository
    {
        public PictureFieldRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<PictureFieldModel>> GetAll()
        {
            var result = await _dbContext.Picturefield.AsNoTracking().ToListAsync();
            return result;
        }

    }
}
