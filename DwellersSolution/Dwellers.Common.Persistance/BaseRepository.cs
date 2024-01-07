using Dwellers.Common.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedKernel;
using SharedKernel.Application;
using System.Data;

namespace Dwellers.Common.Persistance
{
    public class BaseRepository : ITransaction
    {
        protected readonly DwellerDbContext _context;
        private IDbContextTransaction _transaction;

        public BaseRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<ITransaction> BeginTransactionAsync
         (IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
            {
                if (_transaction == null)
                {
                    _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
                }
                return this;
            }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

    }
}
