using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerEvents
{
    internal class DwellerEventsQueryRepository : IDwellerEventsQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerEventsQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerEventEntity>> GetAllEvents(Guid houseId)
        {
            return await _context.DwellerEvents
                    .Include(e => e.House)
                    .Include(e => e.User)
                    .Where(e => e.House.HouseId == houseId)
                    .ToListAsync();
        }

        public async Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid houseId)
        {
             return await _context.DwellerEvents
                .Include(e => e.User)
                .Where(e => e.House != null && e.House.HouseId == houseId)
                .Where(e => !e.Archived)
                .OrderByDescending(e => e.EventDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<DwellerEventEntity> GetEvent(Guid eventId)
        {
            return await _context.DwellerEvents.Where(e => e.Id == eventId).SingleOrDefaultAsync();
        }
    }
}
