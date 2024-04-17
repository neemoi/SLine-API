using Application.DtoModels.Models.User.Order;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("/Orders")]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrdersForUser(CreateOrder model)
        {
            try
            {
                return Ok(await _orderService.CreateOrderAsync(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetOrders/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(string userId)
        {
            try
            {
                return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("CancelOrder")]
        public async Task<IActionResult> CancelOrderAsync(int orderId, string userId)
        {
            try
            {
                return Ok(await _orderService.CancelOrderAsync(orderId, userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
