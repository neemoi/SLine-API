using Application.DtoModels.Models.User;
using YourNamespace.DtoModels.Response;

namespace Application.Services.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrder model);
    }
}
