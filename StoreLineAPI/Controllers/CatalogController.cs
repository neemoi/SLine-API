using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("/Catalog")]
    //[Authorize]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await _catalogService.GetCategoriesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Categories/{categoryId}")]
        public async Task<IActionResult> GetSubcategoriesByCategoryId(int categoryId)
        {
            try
            {
                return Ok(await _catalogService.GetSubcategoriesByIdAsync(categoryId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Subcategories/{subcategoryId}")]
        public async Task<IActionResult> GetProductsBySubcategoryId(int subcategoryId)
        {
            try
            {
                return Ok(await _catalogService.GetProductsBySubcategoryIdAsync(subcategoryId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _catalogService.GetAllProductsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Products/{productName}")]
        public async Task<IActionResult> GetProductByNameAsync(string productName)
        {
            try
            {
                return Ok(await _catalogService.GetProductsByNameAsync(productName));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Product/{productId}")]
        public async Task<IActionResult> GetProductsByIdAsync(int productId)
        {
            try
            {
                return Ok(await _catalogService.GetProductsByIdAsync(productId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
