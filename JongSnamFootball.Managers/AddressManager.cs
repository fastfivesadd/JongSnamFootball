using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;

namespace JongSnamFootball.Managers
{
    public class AddressManager : IAddressManager
    {
        private readonly ISubDistrictRepository _subDistrictRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvinceRepository _provinceRepository;
        public AddressManager(ISubDistrictRepository subDistrictRepository, IDistrictRepository districtRepository, IProvinceRepository provinceRepository)
        {
            _subDistrictRepository = subDistrictRepository;
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
        }

        public async Task<List<ProvinceModel>> GetProvinces()
        {
            var provincesModel = await _provinceRepository.GetProvinces();
            return provincesModel;
        }

        public async Task<ProvinceModel> GetProvinceById(int Id)
        {
            var provincesModel = await _provinceRepository.GetProvinceById(Id);
            return provincesModel;
        }

        public async Task<List<DistrictModel>> GetDistrictByProvinceId(int ProvinceId)
        {
            var districtModel = await _districtRepository.GetDistrictByProvinceId(ProvinceId);
            return districtModel;

        }
        public async Task<DistrictModel> GetDistrictById(int Id)
        {
            var districtModel = await _districtRepository.GetDistrictById(Id);
            return districtModel;
        }

        public async Task<List<SubDistrictModel>> GetSubDistrictByDistrictId(int DistrictId)
        {
            var subDistrictModel = await _subDistrictRepository.GetSubDistrictByDistrictId(DistrictId);
            return subDistrictModel;
        }
        public async Task<SubDistrictModel> GetSubDistrictById(int Id)
        {
            var subDistrictModel = await _subDistrictRepository.GetSubDistrictById(Id);
            return subDistrictModel;
        }

    }
}
