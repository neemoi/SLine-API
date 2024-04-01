using Application.Services.Interfaces.IRepository;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; } // Сделайте свойство публичным

        Task SaveChangesAsync();
    }
}
