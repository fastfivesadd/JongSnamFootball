using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;
        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        [HttpGet("{storeId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<FieldDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetYourReservation(int storeId, int currentPage, int pageSize)
        {
            return Ok(await _reservationManager.GetYourReservation(storeId, currentPage, pageSize));
        }

        [HttpGet("{Id}/Detail")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(BasePagingDto<ReservationDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasePagingDto<FieldDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetShowDetailYourReservation(int Id)
        {
            return Ok(await _reservationManager.GetShowDetailYourReservation(Id));
        }
    }
    
}
