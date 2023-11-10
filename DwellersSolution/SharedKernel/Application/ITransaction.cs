namespace SharedKernel.Application
{
    public interface ITransaction
    {
        Task CommitAsync();
        Task RollbackAsync();
        ITransaction BeginTransaction();
        Task<bool> Save();
    }
}
