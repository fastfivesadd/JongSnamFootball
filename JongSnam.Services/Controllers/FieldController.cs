using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnam.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldManager _fieldManager;
        public FieldController(IFieldManager fieldManager)
        {
            _fieldManager = fieldManager;
        }

        [HttpGet("{fieldId}")]
        public async Task<List<ListFieldByIdFieldDto>> GetFieldByField(int fieldId)
        {
            return await _fieldManager.GetFieldByField(fieldId);

        }

        [HttpGet("{storeId}/{currentPage}")]
        public async Task<BasePagingDto<FieldDto>> GetFieldByStore(int storeId, int currentPage, int pageSize)
        {
            return await _fieldManager.GetFieldByStore(storeId, currentPage, pageSize);

        }
    }
}
