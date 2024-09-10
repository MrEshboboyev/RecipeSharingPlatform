using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Application.Common.Models;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // inject Auth Service
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _authService.LoginAsync(loginModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                await _authService.RegisterAsync(registerModel);
                return Ok("Registration successful!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
