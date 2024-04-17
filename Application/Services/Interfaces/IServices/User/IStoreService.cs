using Application.DtoModels.Response.User.Store;

namespace Application.Services.Interfaces.IServices.User
{
    public interface IStoreService
    {
        Task<List<ChainOfStoreResponseDto>> GetAllChainsAsync();

        Task<List<StoreResponseDto>> GetAllStoresAsync();
    }
}
