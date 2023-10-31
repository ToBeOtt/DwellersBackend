using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Calendar.Repositories
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

        public async Task<bool> AddEvent(DwellerEventEntity dwellerEvent)
        {
            await _context.DwellerEvents.AddAsync(dwellerEvent);
            int result = await SaveActions();
            return result > 0;

        }
    }
}
