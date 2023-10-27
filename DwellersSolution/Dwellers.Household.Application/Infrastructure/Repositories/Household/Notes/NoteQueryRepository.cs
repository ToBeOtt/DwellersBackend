using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Domain.Entities.Notes;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.Household.Meetings
{
    public class NoteQueryRepository : INoteQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public NoteQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Note>> GetNotes(Guid houseId)
        {
            return await _context.Notes
                         .Include(mp => mp.User)
                             .ThenInclude(u => u.HouseUsers)
                                 .ThenInclude(hu => hu.House)
                         .Where(mp => mp.User.HouseUsers.Any(hu => hu.HouseId == houseId))
                         .ToListAsync();
        }

        public async Task<ICollection<Note>> SortNotesByCategory(Guid houseId, int? noteCategory)
        {
            return await _context.Notes
                            .Include(mp => mp.User)
                                .ThenInclude(u => u.HouseUsers)
                                    .ThenInclude(hu => hu.House)
                            .Where(mp => mp.User.HouseUsers.Any(hu => hu.HouseId == houseId)
                                       && (noteCategory == null || (int)mp.Category == noteCategory))
                            .ToListAsync();
        }

        public async Task<ICollection<Noteholder>> GetNoteholders(Guid houseId)
        {
            return await _context.Noteholders
                            .Include(nh => nh.NoteholderNotes)
                                .ThenInclude(nhn => nhn.Note)
                            .Include(nh => nh.HouseNoteholders)
                                .ThenInclude(hn => hn.House)
                            .Where(nh => nh.HouseNoteholders.Any(hn => hn.HouseId == houseId))
                            .ToListAsync();
        }

        public async Task<Noteholder> GetFullNoteholderById(Guid noteholderId, Guid houseId)
        {
            return await _context.Noteholders
                        .Include(nh => nh.HouseNoteholders)
                        .Where(nh => nh.HouseNoteholders.Any(hn => hn.HouseId == houseId && hn.NoteholderId == noteholderId))
                        .SingleOrDefaultAsync();
        }
        Task<Noteholder> INoteQueryRepository.GetNoteholderById(Guid noteholderId)
        {
            return _context.Noteholders.Where(n => n.NoteholderId == noteholderId).FirstOrDefaultAsync();
        }

        public async Task<Note> GetNoteById(Guid noteId)
        {
            return await _context.Notes.Where(n => n.NoteId == noteId).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Note>> GetNotesForNoteholder(Guid noteholderId)
        {
            return await _context.Notes
                      .Where(n => n.NoteholderNotes
                      .Any(nh => nh.NoteholderId == noteholderId))
                      .ToListAsync();
        }

        public async Task<ICollection<Note>> GetNewOrUpdatedNotes(Guid houseId)
        {
            return await _context.Notes
                .Include(n => n.User)
                .Where(n => n.House != null && n.House.HouseId == houseId)
                .Where(n => !n.Archived)
                .OrderByDescending(n => n.NoteCreated)
                .ThenByDescending(n => n.NoteModified)
                .Where(n => n.NoteCreated >= DateTime.UtcNow.AddDays(-10))
                .Take(10)
                .ToListAsync();
        }

        public async Task<ICollection<Noteholder>> GetNewOrUpdatedNoteholders(Guid houseId)
        {
            return await _context.Noteholders
                .Include(nh => nh.HouseNoteholders)
                    .ThenInclude(hn => hn.House)
                .Include(nh => nh.NoteholderNotes)
                    .ThenInclude(nhn => nhn.Note)
                .Where(nh => !nh.Archived)
                .OrderByDescending(nh => nh.DateCreated)
                .ThenByDescending(nh => nh.DateUpdated)
                .Take(10)
                .ToListAsync();
        }
    }
}
