using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IStoreRepository : IRepository<StoreModel>
    {
        Task<List<StoreModel>> GetAll();

        Task<StoreModel> GetStoreById(int Id);
        Task<List<StoreModel>> GetStoreByOwnerId(int? ownerId);

    
    }
}
