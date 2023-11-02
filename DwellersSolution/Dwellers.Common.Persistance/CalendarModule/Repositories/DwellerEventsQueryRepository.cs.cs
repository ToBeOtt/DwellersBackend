using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerEvents;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.CalendarModule.Interfaces
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
                    .Where(e => e.House.Id == houseId)
                    .ToListAsync();
        }

        public async Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid houseId)
        {
             return await _context.DwellerEvents
                .Include(e => e.User)
                .Where(e => e.House != null && e.House.Id == houseId)
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
