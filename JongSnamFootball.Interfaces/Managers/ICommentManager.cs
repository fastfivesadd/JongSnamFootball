using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface ICommentManager
    {
        //Task<BasePagingDto<CommentDto>> GetFieldByStore(int storeId, int currentPage, int pageSize);

        Task<BasePagingDto<CommentDto>> GetCommentByStoreId(int storeId, int currentPage, int pageSize);
    }
}
