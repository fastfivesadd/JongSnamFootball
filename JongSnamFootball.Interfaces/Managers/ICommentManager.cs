using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface ICommentManager
    {
        //Task<BasePagingDto<CommentDto>> GetFieldByStore(int storeId, int currentPage, int pageSize);

        Task<SumaryRatingDto> GetCommentByStoreId(int storeId, int currentPage, int pageSize);
    }
}
