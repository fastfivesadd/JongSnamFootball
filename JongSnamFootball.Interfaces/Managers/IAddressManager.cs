using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IAddressManager
    {
        Task<List<ProvinceModel>> GetProvinces();

        Task<ProvinceModel> GetProvinceById(int Id);

        Task<List<DistrictModel>> GetDistrictByProvinceId(int ProvinceId);

        Task<DistrictModel> GetDistrictById(int Id);

        Task<List<SubDistrictModel>> GetSubDistrictByDistrictId(int DistrictId);

        Task<SubDistrictModel> GetSubDistrictById(int Id);
    }
}
