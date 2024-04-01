namespace Application.UnitOfWork
{
    internal interface IUnitOfWork
    {


        Task SaveChangesAsync();
    }
}
