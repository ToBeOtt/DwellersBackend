using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerEvents
{
    public class DwellerEventsCommandRepository : IDwellerEventsCommandRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly ILogger<DwellerEventsCommandRepository> _logger;

        public DwellerEventsCommandRepository(
            HouseholdDbContext context,
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
            await _context.Events.AddAsync(dwellerEvent);
            int result = await SaveActions();
            return result > 0;

        }
    }
}
