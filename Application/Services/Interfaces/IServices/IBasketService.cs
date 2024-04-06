using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;

namespace Application.Services.Interfaces.IServices
{
    public interface IBasketService
    {
        Task<UserCartResponseDto> AddProductToCartAsync(CartDto model);

        Task<List<UserCartResponseDto>> GetCartItemsAsync(string userId);

        Task<List<GetProductsStoresResponseDto>> GetProductsAvailableStores(int productId);

        //Task<UserCartResponseDto> DeleteBacketProductsAsync(string userId);

        //Task<UserCartResponseDto> DeleteBasketProductByIdAsync(string userId, int productId);
    }
}
