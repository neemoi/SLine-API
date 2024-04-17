using Persistance;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IStoreRepository
    {
        Task<List<ChainOfStore>> GetAllChainsAsync();

        Task<List<Store>> GetAllStoresAsync();
    }
}
