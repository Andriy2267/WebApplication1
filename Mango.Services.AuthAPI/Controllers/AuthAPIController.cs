using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        [HttpPost(Name ="register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost(Name ="login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
