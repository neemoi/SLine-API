using Application.Services.Interfaces.IRepository;
using Application.UnitOfWork;
using Persistance.Context;

namespace Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; }

        public ICatalogRepository CatalogRepository { get; }

        private readonly StoreLineContext _storeLineContext;

        public UnitOfWork(StoreLineContext storeLineContext, IStoreRepository storeRepository, ICatalogRepository catalogRepository)
        {
            _storeLineContext = storeLineContext;
            StoreRepository = storeRepository;
            CatalogRepository = catalogRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _storeLineContext.SaveChangesAsync();
        }

    }
}
