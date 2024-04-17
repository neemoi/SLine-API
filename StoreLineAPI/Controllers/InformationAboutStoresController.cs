using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("/Store")]
    //[Authorize]
    public class InformationAboutStoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public InformationAboutStoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("AllStores")]
        public async Task<IActionResult> GetAllStores()
        {
            try
            {
                return Ok(await _storeService.GetAllStoresAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

        [HttpGet("Chains")]
        public async Task<IActionResult> GetAllChains()
        {
            try
            {
                return Ok(await _storeService.GetAllChainsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}