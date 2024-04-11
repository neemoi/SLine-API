using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface IStoreRepository
    {
        Task<List<ChainOfStore>> GetAllChainsAsync();

        Task<List<Store>> GetAllStoresAsync();
    }
}
