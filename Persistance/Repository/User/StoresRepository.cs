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
                var chains = await _storeLineContext.ChainOfStores.ToListAsync();

                if (chains != null)
                {
                    return chains;
                }
                else
                {
                    throw new Exception($"Chains not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in StoresRepository -> GetAllChainsAsync: {ex.Message}");
            }
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            try
            {
                var stores = await _storeLineContext.Stores
                    .Include(store => store.Chain)
                    .ToListAsync();

                if (stores != null)
                {
                    return stores;
                }
                else
                {
                    throw new Exception($"Stores not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in StoresRepository -> GetAllStoresAsync: {ex.Message}");
            }
        }
    }
}
