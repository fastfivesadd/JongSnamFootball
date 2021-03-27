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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost("/Login")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
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
    }
}
