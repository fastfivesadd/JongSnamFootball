using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class ProvinceRepository : BaseRepository<ProvinceModel>, IProvinceRepository
    {
        public ProvinceRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<ProvinceModel>> GetProvinces()
        {
            var result = await _dbContext.Provinces.AsNoTracking().ToListAsync();
            return result;
        }

    }
}
