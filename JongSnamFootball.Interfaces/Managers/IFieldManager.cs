using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IFieldManager
    {
        Task<BasePagingDto<FieldDto>> GetFieldBySearch(SearchFieldRequest request, int currentPage, int pageSize);

        Task<BasePagingDto<FieldDto>> GetFieldByStoreId(int storeId, int currentPage, int pageSize);

        Task<FieldDetailDto> GetFieldById(int id);

        Task<bool> AddField(AddFieldRequest requestDto);

        Task<bool> UpdeteField(int id, UpdateFieldRequest updateFieldRequest);

        Task<bool> DeleteField(int id);
    }
}
