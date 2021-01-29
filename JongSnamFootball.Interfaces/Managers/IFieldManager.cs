using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IFieldManager
    {
        Task<BasePagingDto<FieldDto>> GetFieldByStoreId(int storeId, int currentPage, int pageSize);

        Task<FieldByIdFieldDto> GetFieldById(int id);

        Task<bool> AddField(AddFieldRequest requestDto);

        Task<bool> UpdeteField(int id, UpdateFieldRequest updateFieldRequest);
    }
}
