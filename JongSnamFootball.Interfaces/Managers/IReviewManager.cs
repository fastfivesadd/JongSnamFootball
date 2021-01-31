using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IReviewManager
    {
        Task<SumaryRatingDto> GetReviewByStoreId(int storeId, int currentPage, int pageSize);
    }
}
