﻿using Application.DtoModels.Models.User.Order;
using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(CreateOrder model);

        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        Task<Order> CancelOrderAsync(int orderId, string userId);
    }
}
