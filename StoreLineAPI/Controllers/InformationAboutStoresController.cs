using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("api/Store")]
    [Authorize]
    public class InformationAboutStoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public InformationAboutStoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("/Stores")]
        public async Task<IActionResult> GetAllStores()
        {
            try
            {
                return Ok(await _storeService.GetAllStoresAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("/Chains")]
        public async Task<IActionResult> GetAllChains()
        {
            try
            {
                return Ok(await _storeService.GetAllChainsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}