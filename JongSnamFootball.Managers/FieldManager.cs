using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class FieldManager : IFieldManager
    {
        private readonly IMapper _mapper;
        private readonly IFieldRepository _fieldRepository;

        public FieldManager(IMapper mapper, IFieldRepository fieldRepository)
        {
            _mapper = mapper;
            _fieldRepository = fieldRepository;
        }

        public async Task<BasePagingDto<FieldDto>> GetFieldByStore(int storeId, int currentPage, int pageSize)
        {
            var listStore = await _fieldRepository.GetByStoreID(storeId);

            var listFieldDto = _mapper.Map<List<FieldDto>>(listStore);

            var result = MakePaging.FieldDtotoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }

        public async Task<List<ListFieldByIdFieldDto>> GetFieldById(int id)
        {
            var listStore = await _fieldRepository.GetByFieldId(id);

            var result = _mapper.Map<List<ListFieldByIdFieldDto>>(listStore);

            return result;
        }


    }
}
