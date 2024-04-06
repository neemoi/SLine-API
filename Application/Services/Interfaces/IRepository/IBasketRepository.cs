using Application.DtoModels.Models.User;
using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface IBasketRepository
    {
        Task<UserCart> AddProductToCartAsync(CartDto model);

        Task<List<UserCart>> GetCartItemsAsync(string userId);

        Task<List<Warehouse>> GetProductsAvailableStores(int productId);

        //Task<UserCart> DeleteBacketProductsAsync(string userId);

        //Task<UserCart> DeleteBasketProductByIdAsync(string userId, int productId);
    }
}
