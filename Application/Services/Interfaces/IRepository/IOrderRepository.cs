using Application.DtoModels.Models.User;
using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(CreateOrder model);

        //Task<UserCart> GetUserCartByUserIdAsync(string userId);
    }
}
