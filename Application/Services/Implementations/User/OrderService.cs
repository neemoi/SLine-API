using Application.DtoModels.Models.User.Order;
using Application.Services.Interfaces.IServices;
using Application.UnitOfWork;
using AutoMapper;
using YourNamespace.DtoModels.Response;

namespace Application.Services.Implementations.User
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponseDto> CancelOrderAsync(int orderId, string userId)
        {
            try
            {
                var result = await _unitOfWork.OrderRepository.CancelOrderAsync(orderId, userId);

                return _mapper.Map<OrderResponseDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in Service -> CancelOrderAsync: {ex.Message}");
            }
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrder model)
        {
            try
            {
                var result = await _unitOfWork.OrderRepository.CreateOrderAsync(model);

                return _mapper.Map<OrderResponseDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in Service -> CreateOrderAsync: {ex.Message}");
            }
        }

        public async Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.OrderRepository.GetOrdersByUserIdAsync(userId);

                return _mapper.Map<List<OrderResponseDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in Service -> GetOrdersByUserIdAsync: {ex.Message}");
            }
        }
    }
}
