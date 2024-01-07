using System.Data;

namespace SharedKernel
{
    public interface ITransaction
    {
        Task CommitAsync();
        Task RollbackAsync();
        Task<ITransaction> BeginTransactionAsync
            (IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<bool> Save();
    }
}
