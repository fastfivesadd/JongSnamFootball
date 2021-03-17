using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IFieldRepository : IRepository<FieldModel>
    {
        Task<List<FieldModel>> GetFieldBySearch(SearchFieldRequest request);

        Task<List<FieldModel>> GetByStoreId(int? storeID);

        Task<FieldModel> GetFieldById(int id);
    }
}
