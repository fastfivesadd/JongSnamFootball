using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IStoreManager
    {
        Task<BasePagingDto<StoreDto>> GetListStore(int currentPage, int pageSize);

        Task<BasePagingDto<YourStore>> GetYourStores(int ownerId, int currentPage, int pageSize);

        Task<bool> AddStore(StoreRequest requestDto);

        Task<bool> UpdateStore(int id, UpdateStoreRequest request);
    }
}
