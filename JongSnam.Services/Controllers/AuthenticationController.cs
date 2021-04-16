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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUserManager _userManager;

        public AuthenticationController(IAuthenticationManager authenticationManager, IUserManager userManager)
        {
            _authenticationManager = authenticationManager;
            _userManager = userManager;
        }

        [HttpPost("/Login")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(UserDto))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> Login(string user, string password)
        {
            return Ok(await _authenticationManager.Login(user, password));
        }

        [HttpPost("/Logout")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> Logout(int id)
        {
            return Ok(await _authenticationManager.Logout(id));
        }

        [HttpPost("/Register")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemsDetailDto))]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest requestDto)
        {
            var result = await _userManager.CreateUser(requestDto);
            return Ok(result);
        }
    }
}
