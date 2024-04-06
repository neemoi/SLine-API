using Application.DtoModels.Models.User;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("Basket")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProductToCartAsync(CartDto model)
        {
            try
            {
                var result = await _basketService.AddProductToCartAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/CartItems")]
        public async Task<IActionResult> GetCartItemsAsync(string userId)
        {
            try
            {
                var result = await _basketService.GetCartItemsAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/AvailableStores")]
        public async Task<IActionResult> GetProductsAvailableStores(int productId)
        {
            try
            {
                var result = await _basketService.GetProductsAvailableStores(productId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
