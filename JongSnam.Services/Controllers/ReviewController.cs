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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManager _reviewManager;
        public ReviewController(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        [HttpGet("{storeId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(SumaryRatingDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SumaryRatingDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetReviewByStoreId(int storeId, int currentPage, int pageSize)
        {
            return Ok(await _reviewManager.GetReviewByStoreId(storeId, currentPage, pageSize));
        }
    }
}
