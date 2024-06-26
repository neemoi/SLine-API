﻿using Application.DtoModels.Models.User.Cart;
using Application.DtoModels.Response.User;

namespace Application.Services.Interfaces.IServices
{
    public interface IBasketService
    {
        Task<UserBasketResponseDto> AddProductToBasketAsync(BasketDto model);

        Task<List<UserBasketResponseDto>> GetBasketItemsAsync(string userId);

        Task<List<GetProductsStoresResponseDto>> GetProductsAvailableStores(int productId);

        Task<UserBasketResponseDto> UpdateBasketItemQuantityAsync(UpdateBasketItemDto model);

        Task<UserBasketResponseDto> RemoveProductBasketAsync(DeleteBasketProductDto model);

        Task<List<UserBasketResponseDto>> RemoveAllUserBasketAsync(string userId);
    }
}
