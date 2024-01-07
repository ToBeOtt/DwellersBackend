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
        public async Task<ICollection<DwellerEventEntity>> GetAllEvents(Guid dwellingId)
        {
            return await _context.DwellerEvents
                    .Include(e => e.Dwelling)
                    .Include(e => e.Dweller)
                    .Where(e => e.Dwelling.Id.Value == dwellingId)
                    .ToListAsync();
        }

        public async Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid dwellingId)
        {
             return await _context.DwellerEvents
                .Include(e => e.Dweller)
                .Where(e => e.Dwelling != null && e.Dwelling.Id.Value == dwellingId)
                .Where(e => !e.IsArchived)
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
