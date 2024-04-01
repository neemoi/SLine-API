using Application.Services.Interfaces.IRepository;
using Application.UnitOfWork;
using Persistance.Context;

namespace Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; }



        private readonly StoreLineContext _storeLineContext;

        public UnitOfWork(StoreLineContext storeLineContext, IStoreRepository storeRepository)
        {
            _storeLineContext = storeLineContext;
            StoreRepository = storeRepository;
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
