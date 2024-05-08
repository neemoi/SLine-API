﻿using Application.DtoModels.Models.User.Order;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [ApiController]
    [Route("/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Delivery/{storeId}")]
        public async Task<IActionResult> GetDeliveryAsync(int storeId)
        {
            try
            {
                return Ok(await _orderService.GetDelivery(storeId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("OrderStatus")]
        public async Task<IActionResult> GetOrderStatusAsync()
        {
            try
            {
                return Ok(await _orderService.GetOrderStatus());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("PaymentType")]
        public async Task<IActionResult> GetPaymentTypeAsync()
        {
            try
            {
                return Ok(await _orderService.GetPaymentType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrdersForUserAsync(CreateOrder model)
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
        public async Task<IActionResult> GetOrdersByUserIdAsync(string userId)
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
