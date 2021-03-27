using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IProvinceRepository
    {
        Task<List<ProvinceModel>> GetProvinces();

        Task<ProvinceModel> GetProvinceById(int id);
    }
}
