using Application.DtoModels.Models.User;
using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface IBasketRepository
    {
        Task<UserCart> AddProductToCartAsync(CartDto model);

        Task<List<UserCart>> GetCartItemsAsync(string userId);

        Task<List<Warehouse>> GetProductsAvailableStores(int productId);

        Task<UserCart> RemoveProductByIdCartAsync(DeleteCartProductDto model);

        Task<List<UserCart>> RemoveUserCartAsync(string userId);
    }
}
