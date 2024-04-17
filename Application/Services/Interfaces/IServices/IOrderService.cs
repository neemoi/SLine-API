using Application.DtoModels.Models.User.Order;
using YourNamespace.DtoModels.Response;

namespace Application.Services.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrder model);

        Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(string userId);

        Task<OrderResponseDto> CancelOrderAsync(int orderId, string userId);
    }
}
