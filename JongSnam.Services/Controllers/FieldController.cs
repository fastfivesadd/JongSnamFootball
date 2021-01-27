using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
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
        [Produces("application/json", Type = typeof(ListFieldByIdFieldDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ListFieldByIdFieldDto))]
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
            return Ok(await _fieldManager.GetFieldByStore(storeId, currentPage, pageSize));
        }
    }
}
