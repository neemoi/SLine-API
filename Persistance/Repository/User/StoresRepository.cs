using Application.Services.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repository.User
{
    public class StoresRepository : IStoreRepository
    {
        private readonly StoreLineContext _storeLineContext;

        public StoresRepository(StoreLineContext storeLineContext)
        {
            _storeLineContext = storeLineContext;
        }

        public async Task<List<ChainOfStore>> GetAllChainsAsync()
        {
            try
            {
                return await _storeLineContext.ChainOfStores.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            try
            {
                return await _storeLineContext.Stores
                    .Include(store => store.Chain)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw; 
            }
        }
    }
}
