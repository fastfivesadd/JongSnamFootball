using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<List<CommentModel>> GetAll();

        Task<List<CommentModel>> GetCommentByStoreId(int storeID);

    }
}
