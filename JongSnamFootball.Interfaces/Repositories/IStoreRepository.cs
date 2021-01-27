using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        Task<List<StoreModel>> GetAll();

        Task<List<StoreModel>> GetStoreByOwnerId(int? ownerId);

        Task<StoreModel> GetCommentByStoreId(int? storeID);
    }
}
