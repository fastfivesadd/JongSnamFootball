using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IFieldRepository
    {
        Task<List<FieldModel>> GetAll();

        Task<List<FieldModel>> GetByStoreID(int? storeID);

        Task<List<FieldModel>> GetByFieldId(int? fieldID);
    }
}
