using Application.DtoModels.Models.User.Cart;
using Application.DtoModels.Response.User.Basket;
using Application.DtoModels.Response.User.Product;
using Application.Services.Interfaces.IServices.User;
using Application.UnitOfWork;
using AutoMapper;

namespace Application.Services.Implementations.User
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserBasketResponseDto> AddProductToBasketAsync(BasketDto model)
        {
            try
            {
                var result = await _unitOfWork.BasketRepository.AddProductToBasketAsync(model);

                return _mapper.Map<UserBasketResponseDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> AddProductToBasketAsync: {ex.Message}");
            }
        }

        public async Task<List<UserBasketResponseDto>> GetBasketItemsAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.BasketRepository.GetBasketItemsAsync(userId);

                return _mapper.Map<List<UserBasketResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> GetBasketItemsAsync: {ex.Message}");
            }
        }

        public async Task<List<GetProductsStoresResponseDto>> GetProductsAvailableStores(int productId)
        {
            try
            {
                var warehouses = await _unitOfWork.BasketRepository.GetProductsAvailableStores(productId);

                if (warehouses.Any())
                {
                    var resultDto = _mapper.Map<List<GetProductsStoresResponseDto>>(warehouses);

                    resultDto.ForEach(dto => dto.ProductId = productId);

                    return resultDto;
                }
                else
                {
                    throw new Exception($"Product not found for productId: ({productId})");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> GetProductsAvailableStores: {ex.Message}");
            }
        }

        public async Task<UserBasketResponseDto> RemoveProductBasketAsync(DeleteBasketProductDto model)
        {
            try
            {
                var updatedCartItem = await _unitOfWork.BasketRepository.RemoveProductBasketAsync(model);

                return _mapper.Map<UserBasketResponseDto>(updatedCartItem); ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> RemoveProductBasketAsync: {ex.Message}");
            }
        }

        public async Task<List<UserBasketResponseDto>> RemoveAllUserBasketAsync(string userId)
        {
            try
            {
                var updatedCartItem = await _unitOfWork.BasketRepository.RemoveAllUserBasketAsync(userId);

                return _mapper.Map<List<UserBasketResponseDto>>(updatedCartItem); ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> RemoveAllUserBasketAsync: {ex.Message}");
            }
        }

        public async Task<UserBasketResponseDto> UpdateBasketItemQuantityAsync(UpdateBasketItemDto model)
        {
            try
            {
                var  UpdateCartItemQuantity = await _unitOfWork.BasketRepository.UpdateBasketItemQuantityAsync(model);

                return _mapper.Map<UserBasketResponseDto>(UpdateCartItemQuantity); ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in BasketService -> UpdateBasketItemQuantityAsync: {ex.Message}");
            }
        }
    }
}
