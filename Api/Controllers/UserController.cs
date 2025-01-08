using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _UserServ;
        public UserController(IUserService UserServ)
        {
            _UserServ = UserServ;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] UserLoginRequest user)
        {
            return Ok(await _UserServ.ValidateLogin(user));
        }
    }
}
