using System.Collections.Generic;
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
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(IEnumerable<UserDto>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userManager.GetAll());
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(UserDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _userManager.GetById(id));
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(IEnumerable<bool>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest requestDto)
        {
            var result = await _userManager.CreateUser(requestDto);
            return Ok(result);
        }

        [HttpPut("ChangePassword")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> ChangePassword(int id, [FromBody]ChangePasswordRequest request)
        {
            var result = await _userManager.ChangePassword(id, request);
            return Ok(result);
        }
    }
}
