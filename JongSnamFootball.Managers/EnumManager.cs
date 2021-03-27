using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;

namespace JongSnamFootball.Managers
{
    public class EnumManager : IEnumManager
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;

        public EnumManager(
            IProvinceRepository provinceRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository)
        {
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
        }

        public async Task<List<EnumDto>> GetEnum(string enumName, int id)
        {
            var result = new List<EnumDto>();
            if (enumName == "Province")
            {
                var provinces = await _provinceRepository.GetProvinces();

                foreach (var province in provinces)
                {
                    result.Add(new EnumDto
                    {
                        Id = province.Id,
                        Name = province.Name
                    });
                }
            }
            else if (enumName == "District")
            {
                var districts = await _districtRepository.GetDistrictByProvinceId(id);

                foreach (var district in districts)
                {
                    result.Add(new EnumDto
                    {
                        Id = district.Id,
                        Name = district.Name
                    });
                }
            }

            else if (enumName == "SubDistrict")
            {
                var subDistricts = await _subDistrictRepository.GetSubDistrictByDistrictId(id);

                foreach (var subDistrict in subDistricts)
                {
                    result.Add(new EnumDto
                    {
                        Id = subDistrict.Id,
                        Name = subDistrict.Name
                    });
                }
            }

            return result;
        }
    }
}
