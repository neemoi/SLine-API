using Application.DtoModels.Models.Authorization;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("api/Authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IAccountService _accountService;

        public AuthorizationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var response = await _accountService.LoginAsync(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            try
            {
                var response = await _accountService.RegisterAsync(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("/Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                var response = await _accountService.LogoutAsync(HttpContext);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
