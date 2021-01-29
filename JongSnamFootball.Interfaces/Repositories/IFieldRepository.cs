using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IFieldRepository : IRepository<FieldModel>
    {
        Task<List<FieldModel>> GetAll();

        Task<List<FieldModel>> GetByStoreID(int? storeID);

        Task<FieldModel> GetFieldById(int id);
    }
}
