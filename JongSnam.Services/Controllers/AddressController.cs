using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JongSnam.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager _addressManager;
        public AddressController(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }
        [HttpGet("Provinces")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(List<ProvinceModel>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ProvinceModel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetProvinces()
        {
            return Ok(await _addressManager.GetProvinces());
        }

        [HttpGet("{id}/Provinces")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(ProvinceModel))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProvinceModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetProvinceById(int id)
        {
            return Ok(await _addressManager.GetProvinceById(id));
        }

        [HttpGet("{ProvinceId}/GetDistrictByProvinceId")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(List<DistrictModel>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<DistrictModel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetDistrictByProvinceId(int ProvinceId)
        {
            return Ok(await _addressManager.GetDistrictByProvinceId(ProvinceId));
        }
        [HttpGet("{id}/GetDistrictById")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(DistrictModel))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DistrictModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetDistrictById(int id)
        {
            return Ok(await _addressManager.GetDistrictById(id));
        }

        [HttpGet("{DistrictId}/GetSubDistrictByDistrictId")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(List<SubDistrictModel>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<SubDistrictModel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetSubDistrictByDistrictId(int DistrictId)
        {
            return Ok(await _addressManager.GetSubDistrictByDistrictId(DistrictId));
        }

        [HttpGet("{id}/GetSubDistrictById")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(SubDistrictModel))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SubDistrictModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemsDetailDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetSubDistrictById(int id)
        {
            return Ok(await _addressManager.GetSubDistrictById(id));
        }
    }
}
