using Application.DtoModels.Models.User.Order;
using Application.DtoModels.Response.User.Order;
using Persistance;

namespace Application.Services.Interfaces.IServices.User
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrder model);

        Task<List<DeliveryOptionDto>> GetDelivery(int storeId);

        Task<List<OrderStatusDto>> GetOrderStatus();

        Task<List<PaymentDto>> GetPaymentType();

        Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(string userId);

        Task<OrderResponseDto> CancelOrderAsync(int orderId, string userId);
    }
}
