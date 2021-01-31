using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(FieldDetailDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(FieldDetailDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetFieldById(int id)
        {
            return Ok(await _fieldManager.GetFieldById(id));

        }

        [HttpGet("{storeId}/Fields")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<FieldDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<FieldDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetFieldByStore(int storeId, int currentPage, int pageSize)
        {
            return Ok(await _fieldManager.GetFieldByStoreId(storeId, currentPage, pageSize));
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> AddField([FromBody] AddFieldRequest requestDto)
        {
            var result = await _fieldManager.AddField(requestDto);
            return Ok(result);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> UpdateField(int id, [FromBody] UpdateFieldRequest updateFieldRequest)
        {
            var result = await _fieldManager.UpdeteField(id, updateFieldRequest);
            return Ok(result);
        }

        [HttpPut("{id}/DeleteField")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> DeleteField(int id)
        {
            var result = await _fieldManager.DeleteField(id);
            return Ok(result);
        }

    }
}
