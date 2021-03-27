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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;
        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        [HttpGet("{userId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetYourReservation(int userId, int currentPage, int pageSize)
        {
            return Ok(await _reservationManager.GetYourReservation(userId, currentPage, pageSize));
        }

        [HttpGet("Search")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetReservationBySearch(int userId, [FromQuery] SearchReservationRequest request, int currentPage, int pageSize)
        {
            return Ok(await _reservationManager.GetReservationBySearch(userId, request, currentPage, pageSize));
        }

        [HttpGet("{Id}/Detail")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(ReservationDetailDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReservationDetailDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetShowDetailYourReservation(int Id)
        {
            return Ok(await _reservationManager.GetShowDetailYourReservation(Id));
        }

        [HttpPut("ApprovalStatus")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> UpdateApprovalStatus(int id, [FromBody] ReservationApprovalRequest request)
        {
            var result = await _reservationManager.UpdateApprovalStatus(id, request);
            return Ok(result);
        }
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationRequest request)
        {
            var result = await _reservationManager.CreateReservation(request);
            return Ok(result);
        }

        [HttpPut("{id}/DeleteReservation")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var result = await _reservationManager.DeleteReservation(id);
            return Ok(result);
        }
    }

}
