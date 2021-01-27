using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IFieldManager
    {
        Task<BasePagingDto<FieldDto>> GetFieldByStore(int storeId, int currentPage, int pageSize);

        Task<List<ListFieldByIdFieldDto>> GetFieldByField(int fieldId);
    }
}
