using Application.DtoModels.Response.User;

namespace Application.Services.Interfaces.IServices
{
    public interface IStoreService
    {
        Task<List<ChainOfStoreResponseDto>> GetAllChainsAsync();

        Task<List<StoreResponseDto>> GetAllStoresAsync();
    }
}
