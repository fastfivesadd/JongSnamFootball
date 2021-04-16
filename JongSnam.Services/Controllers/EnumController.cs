using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnam.Services.Attributes;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JongSnam.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeTokenHeader]
    public class EnumController : ControllerBase
    {
        private readonly IEnumManager _enumManager;

        public EnumController(IEnumManager enumManager)
        {
            _enumManager = enumManager;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(List<EnumDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<EnumDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetEnums(string enumName, int id)
        {
            return Ok(await _enumManager.GetEnum(enumName, id));

        }

    }
}
