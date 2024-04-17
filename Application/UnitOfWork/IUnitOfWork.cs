using Application.Services.Interfaces.IRepository.User;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; } 

        public ICatalogRepository CatalogRepository { get; }

        public IBasketRepository BasketRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IProfileRepository ProfileRepository { get; }

        Task SaveChangesAsync();
    }
}
