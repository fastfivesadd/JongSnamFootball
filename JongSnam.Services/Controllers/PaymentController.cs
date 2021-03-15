using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet("{reservationId}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(List<PaymentDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<PaymentDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetPaymentByReservationId(int reservationId)
        {
            return Ok(await _paymentManager.GetPaymentByReservationId(reservationId));
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> CreatePayment([FromBody] PaymentRequest request)
        {
            var result = await _paymentManager.AddPayment(request);
            return Ok(result);
        }
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentRequest request)
        {
            var result = await _paymentManager.UpdatePayment(id, request);
            return Ok(result);
        }
    }
}
