using Application.Services.Interfaces.IRepository;
using Application.UnitOfWork;
using Persistance.Context;

namespace Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; }

        public ICatalogRepository CatalogRepository { get; }

        public IBasketRepository BasketRepository { get; }

        public IOrderRepository OrderRepository { get; }

        private readonly StoreLineContext _storeLineContext;

        public UnitOfWork(StoreLineContext storeLineContext, IStoreRepository storeRepository, 
            ICatalogRepository catalogRepository, IBasketRepository basketRepository, IOrderRepository orderRepository)
        {
            _storeLineContext = storeLineContext;
            StoreRepository = storeRepository;
            CatalogRepository = catalogRepository;
            BasketRepository = basketRepository;
            OrderRepository = orderRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _storeLineContext.SaveChangesAsync();
        }

    }
}
