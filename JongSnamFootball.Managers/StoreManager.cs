using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class StoreManager : IStoreManager
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public StoreManager(IStoreRepository storeRepository, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<BasePagingDto<StoreDto>> GetListStore(int currentPage, int pageSize)
        {
            var listStore = await _storeRepository.GetAll();

            var listStoreDto = _mapper.Map<List<StoreDto>>(listStore);

            var result = MakePaging.StoreDtoToPaging(listStoreDto, currentPage, pageSize);

            return result;
        }
        public async Task<StoreDetailDto> GetStoreById(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            var result = _mapper.Map<StoreDetailDto>(store);
            return result;
        }

        public async Task<BasePagingDto<YourStore>> GetYourStores(int ownerId, int currentPage, int pageSize)
        {
            var listStore = await _storeRepository.GetStoreByOwnerId(ownerId);

            var listStoreDto = _mapper.Map<List<YourStore>>(listStore);

            var result = MakePaging.YourStoreDtoToPaging(listStoreDto, currentPage, pageSize);

            return result;
        }
        public async Task<bool> AddStore(StoreRequest requestDto)
        {
            try
            {
                var storeModel = _mapper.Map<StoreModel>(requestDto);

                storeModel.CreatedDate = DateTime.Now;
                storeModel.UpdatedDate = DateTime.Now;

                await _repositoryWrapper.Store.CreateAsync(storeModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateStore(int id, UpdateStoreRequest request)
        {
            try
            {
                var storeModel = await _storeRepository.GetStoreById(id);

                storeModel.Name = request.Name;
                storeModel.Address = request.Address;
                storeModel.SubDistrictId = request.SubDistrict;
                storeModel.DistrictId = request.District;
                storeModel.ProvinceId = request.Province;
                storeModel.ContactMobile = request.ContactMobile;
                storeModel.Latitude = request.Latitude;
                storeModel.Longtitude = request.Longtitude;
                storeModel.Rules = request.Rules;
                storeModel.Image = request.Image;
                storeModel.IsOpen = request.IsOpen;
                storeModel.OfficeHours = request.OfficeHours;
                storeModel.UpdatedDate = DateTime.Now;

                _repositoryWrapper.Store.Updete(storeModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
