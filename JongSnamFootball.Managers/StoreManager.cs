using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class StoreManager : IStoreManager
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        public StoreManager(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<BasePagingDto<StoreDto>> GetListStore(int currentPage, int pageSize)
        {
            var listStore = await _storeRepository.GetAll();

            var listStoreDto = _mapper.Map<List<StoreDto>>(listStore);

            var result = MakePaging.StoreDtoToPaging(listStoreDto, currentPage, pageSize);

            return result;
        }

        public async Task<BasePagingDto<YourStore>> GetYourStore(int ownerId, int currentPage, int pageSize)
        {
            
            var listStore = await _storeRepository.GetByOwnerId(ownerId);

            var listStoreDto = _mapper.Map<List<YourStore>>(listStore);

            var result = MakePaging.YourStoreDtoToPaging(listStoreDto, currentPage, pageSize);

            return result;
        }
    }
}
