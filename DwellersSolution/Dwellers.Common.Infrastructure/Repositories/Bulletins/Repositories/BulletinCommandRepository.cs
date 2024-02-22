using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.Bulletins.Repositories
{
    public class BulletinCommandRepository(DwellerDbContext context, 
        ILogger<BulletinCommandRepository> logger) : IBulletinCommandRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<BulletinCommandRepository> _logger = logger;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> AddBulletin(Bulletin bulletin)
        {
            try
            {
                _ = _context.Bulletins.AddAsync(bulletin);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }   
        public async Task<bool> DeleteBulletin(Bulletin bulletin)
        {
            try
            {
                _ = _context.Bulletins.AddAsync(bulletin);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
                else 
                    return false;
            }
           catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
               
        }

        public async Task<SaveChangesEventArgs> SaveChanges(SaveChangesEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
