﻿using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;
using Application.Services.Interfaces.IServices;
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

        public async Task<UserCartResponseDto> AddProductToCartAsync(CartDto model)
        {
            try
            {
                var result = await _unitOfWork.BasketRepository.AddProductToCartAsync(model);

                return _mapper.Map<UserCartResponseDto>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<UserCartResponseDto>> GetCartItemsAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.BasketRepository.GetCartItemsAsync(userId);

                return _mapper.Map<List<UserCartResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
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
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
