using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;
using Persistance;

namespace Application.Services.Interfaces.IServices
{
    public interface IBasketService
    {
        Task<UserCartResponseDto> AddProductToCartAsync(CartDto model);

        Task<List<UserCartResponseDto>> GetCartItemsAsync(string userId);

        Task<List<GetProductsStoresResponseDto>> GetProductsAvailableStores(int productId);

        Task<UserCartResponseDto> RemoveProductByIdCartAsync(DeleteCartProductDto model);

        Task<List<UserCartResponseDto>> RemoveUserCartAsync(string userId);
    }
}
