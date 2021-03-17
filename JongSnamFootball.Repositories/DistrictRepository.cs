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
    public class DistrictRepository : BaseRepository<DistrictModel>, IDistrictRepository
    {
        public DistrictRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<DistrictModel>> GetDistrictByProvinceId(int ProvinceId)
        {
            return await _dbContext.Districts.Where(w => w.ProvinceId == ProvinceId)
                .Include(i => i.ProvinceModel)
                .AsNoTracking().ToListAsync();
        }


        public async Task<DistrictModel> GetDistrictById(int id)
        {
            return await _dbContext.Districts.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
