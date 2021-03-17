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
    public class SubDistrictRepository : BaseRepository<SubDistrictModel>, ISubDistrictRepository
    {
        public SubDistrictRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<SubDistrictModel>> GetSubDistrictByDistrictId(int DistrictId)
        {
            return await _dbContext.SubDistricts.Where(w => w.DistrictId == DistrictId)
                .Include(i => i.DistrictModel)
                .AsNoTracking().ToListAsync();
        }

        public async Task<SubDistrictModel> GetSubDistrictById(int id)
        {
            return await _dbContext.SubDistricts.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
