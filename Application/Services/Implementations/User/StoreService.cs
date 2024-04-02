using Application.DtoModels.Response.User;
using Application.Services.Interfaces.IServices;
using Application.UnitOfWork;
using AutoMapper;

namespace Application.Services.Implementations.User
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ChainOfStoreResponseDto>> GetAllChainsAsync()
        {
            try
            {
                var result = await _unitOfWork.StoreRepository.GetAllChainsAsync(); 

                return _mapper.Map<List<ChainOfStoreResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<StoreResponseDto>> GetAllStoresAsync()
        {
            try
            {
                var result = await _unitOfWork.StoreRepository.GetAllStoresAsync();

                return _mapper.Map<List<StoreResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
