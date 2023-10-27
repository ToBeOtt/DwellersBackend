using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerEvents
{
    internal class DwellerEventsQueryRepository : IDwellerEventsQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public DwellerEventsQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerEvent>> GetAllEvents(Guid houseId)
        {
            return await _context.Events
                    .Include(e => e.House)
                    .Include(e => e.User)
                    .Where(e => e.House.HouseId == houseId)
                    .ToListAsync();
        }

        public async Task<ICollection<DwellerEvent>> GetUpcomingEvents(Guid houseId)
        {
             return await _context.Events
                .Include(e => e.User)
                .Where(e => e.House != null && e.House.HouseId == houseId)
                .Where(e => !e.Archived)
                .OrderByDescending(e => e.EventDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<DwellerEvent> GetEvent(Guid eventId)
        {
            return await _context.Events.Where(e => e.Id == eventId).SingleOrDefaultAsync();
        }
    }
}
