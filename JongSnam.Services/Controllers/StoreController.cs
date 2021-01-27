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

        [HttpGet("{ownerId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<YourStore>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<YourStore>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetYourStores(int ownerId, int currentPage, int pageSize)
        {
            return Ok(await _storeManager.GetYourStores(ownerId, currentPage, pageSize));
        }
    }
}
