using Application.DtoModels.Models.User.Order;
using Persistance;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(CreateOrder model);

        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        Task<List<DeliveryOptionDto>> GetDelivery(int storeId);

        Task<List<OrderStatusDto>> GetOrderStatus();

        Task<List<PaymentDto>> GetPaymentType();

        Task<Order> CancelOrderAsync(int orderId, string userId);
    }
}
