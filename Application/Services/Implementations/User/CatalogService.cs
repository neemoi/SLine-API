﻿using Application.DtoModels.Response.User;
using Application.Services.Interfaces.IServices;
using Application.UnitOfWork;
using AutoMapper;

namespace Application.Services.Implementations.User
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatalogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetAllProductsAsync();

                return _mapper.Map<List<ProductResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<CategoryResponseDto>> GetCategoriesAsync()
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetCategoriesAsync();

                return _mapper.Map<List<CategoryResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<ProductResponseDto> GetProductsByIdAsync(int productId)
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetProductsByIdAsync(productId);

                return _mapper.Map<ProductResponseDto>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<ProductResponseDto>> GetProductsByNameAsync(string productName)
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetProductsByNameAsync(productName);

                return _mapper.Map<List<ProductResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<ProductResponseDto>> GetProductsBySubcategoryIdAsync(int subcategoryId)
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetProductsBySubcategoryIdAsync(subcategoryId);

                return _mapper.Map<List<ProductResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<SubcategoryResponseDto>> GetSubcategoriesByIdAsync(int categoryId)
        {
            try
            {
                var result = await _unitOfWork.CatalogRepository.GetSubcategoriesByIdAsync(categoryId);

                return _mapper.Map<List<SubcategoryResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
