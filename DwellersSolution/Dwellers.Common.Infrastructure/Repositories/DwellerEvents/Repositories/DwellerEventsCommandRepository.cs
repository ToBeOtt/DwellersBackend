using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.DwellerEvents.Repositories
{
    public class DwellerEventsCommandRepository : IDwellerEventsCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<DwellerEventsCommandRepository> _logger;

        public DwellerEventsCommandRepository(
            DwellerDbContext context,
            ILogger<DwellerEventsCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<int> SaveActions()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
        }

        public async Task<bool> AddEvent(DwellerEvent dwellerEvent)
        {
            await _context.DwellerEvents.AddAsync(dwellerEvent);
            int result = await SaveActions();
            return result > 0;

        }
    }
}
