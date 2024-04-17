using Application.Services.Interfaces.IRepository.User;
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

        public IProfileRepository ProfileRepository { get; }


        private readonly StoreLineContext _storeLineContext;

        public UnitOfWork(StoreLineContext storeLineContext, IStoreRepository storeRepository, 
            ICatalogRepository catalogRepository, IBasketRepository basketRepository, IOrderRepository orderRepository, 
            IProfileRepository profileRepository)
        {
            _storeLineContext = storeLineContext;
            StoreRepository = storeRepository;
            CatalogRepository = catalogRepository;
            BasketRepository = basketRepository;
            OrderRepository = orderRepository;
            ProfileRepository = profileRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _storeLineContext.SaveChangesAsync();
        }

    }
}
