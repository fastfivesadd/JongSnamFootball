using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IDistrictRepository
    {
        Task<List<DistrictModel>> GetDistrictByProvinceId(int ProvinceId);

        Task<DistrictModel> GetDistrictById(int id);
    }
}
