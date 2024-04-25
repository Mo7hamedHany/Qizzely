using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Interfaces.Services;

namespace Qizzely.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto);

            return user is not null ? Ok(user) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = await _userService.RegisterAsync(registerDto);

            return user is not null ? Ok(user) : BadRequest();
        }
    }
}
