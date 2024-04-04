using Application.DtoModels.Models.User;
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
    }
}
