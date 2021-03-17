using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    class PictureFieldRepository : BaseRepository<ImageFieldModel>, IPictureFieldRepository
    {
        public PictureFieldRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<ImageFieldModel>> GetAll()
        {
            var result = await _dbContext.ImagesField.AsNoTracking().ToListAsync();
            return result;
        }

    }
}
