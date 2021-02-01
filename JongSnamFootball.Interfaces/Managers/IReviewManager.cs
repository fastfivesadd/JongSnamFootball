using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IReviewManager
    {
        Task<SumaryRatingDto> GetReviewByStoreId(int storeId, int currentPage, int pageSize);

        Task<bool> AddReview(ReviewRequest request);
    }
}
