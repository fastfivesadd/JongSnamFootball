using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IReviewRepository : IRepository<ReviewModel>
    {
        Task<List<ReviewModel>> GetAll();

        Task<List<ReviewModel>> GetReviewByStoreId(int storeID);

    }
}
