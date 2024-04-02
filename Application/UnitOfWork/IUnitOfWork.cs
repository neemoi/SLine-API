using Application.Services.Interfaces.IRepository;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; } 

        public ICatalogRepository CatalogRepository { get; }

        Task SaveChangesAsync();
    }
}
