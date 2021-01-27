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
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        //[HttpGet("{storeId}")]
        //public async Task<BasePagingDto<CommentDto>> GetFieldByStore(int storeId, int currentPage, int pageSize)
        //{
        //    return await _commentManager.GetFieldByStore(storeId, currentPage, pageSize);
        //}

        [HttpGet("{storeId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(SumaryRatingDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SumaryRatingDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetCommentByStoreId(int storeId, int currentPage, int pageSize)
        {
            return Ok(await _commentManager.GetCommentByStoreId(storeId, currentPage, pageSize));
        }
    }
}
