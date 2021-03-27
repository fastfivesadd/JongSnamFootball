using System.Threading.Tasks;
using JongSnam.Services.Attributes;
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
    [AuthorizeTokenHeader]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager _storeManager;

        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<StoreDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<StoreDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetStores(int currentPage, int pageSize)
        {
            return Ok(await _storeManager.GetListStore(currentPage, pageSize));
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(StoreDetailDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StoreDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetStoreById(int id)
        {
            return Ok(await _storeManager.GetStoreById(id));
        }

        [HttpGet("{ownerId}/Detail")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<YourStore>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<YourStore>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetYourStores(int ownerId, int currentPage, int pageSize)
        {
            return Ok(await _storeManager.GetYourStores(ownerId, currentPage, pageSize));
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> AddStore([FromBody] StoreRequest requestDto)
        {
            var result = await _storeManager.AddStore(requestDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> UpdateStore(int id, [FromBody] UpdateStoreRequest request)
        {
            var result = await _storeManager.UpdateStore(id, request);
            return Ok(result);
        }
    }
}
