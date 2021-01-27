using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IStoreManager
    {
        Task<BasePagingDto<StoreDto>> GetListStore(int currentPage, int pageSize);

        Task<BasePagingDto<YourStore>> GetYourStores(int ownerId, int currentPage, int pageSize);
    }
}
