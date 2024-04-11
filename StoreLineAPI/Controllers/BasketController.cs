using Application.DtoModels.Models.User.Cart;
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
        public async Task<IActionResult> AddProductToBasketAsync(BasketDto model)
        {
            try
            {
                var result = await _basketService.AddProductToBasketAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("/UpdateQuantity")]
        public async Task<IActionResult> UpdateBasketItemQuantityAsync(UpdateBasketItemDto model)
        {
            try
            {
                var result = await _basketService.UpdateBasketItemQuantityAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/BasketItems")]
        public async Task<IActionResult> GetBasketItemsAsync(string userId)
        {
            try
            {
                var result = await _basketService.GetBasketItemsAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/AvailableStores/{productId}")]
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

        [HttpDelete("/RemoveProduct")]
        public async Task<IActionResult> RemoveProductBasketAsync(DeleteBasketProductDto model)
        {
            try
            {
                var result = await _basketService.RemoveProductBasketAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("/RemoveBasket/{userId}")]
        public async Task<IActionResult> RemoveAllUserBasketAsync(string userId)
        {
            try
            {
                var result = await _basketService.RemoveAllUserBasketAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
