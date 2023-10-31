using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.Notes;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Domain.Entities.Notes;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.Household.Meetings
{
    public class NoteQueryRepository : INoteQueryRepository
    {
        private readonly DwellerDbContext _context;

        public NoteQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<NoteEntity>> GetNotes(Guid houseId)
        {
            return await _context.Notes
                         .Include(mp => mp.User)
                             .ThenInclude(u => u.HouseUsers)
                                 .ThenInclude(hu => hu.House)
                         .Where(mp => mp.User.HouseUsers.Any(hu => hu.HouseId == houseId))
                         .ToListAsync();
        }

        public async Task<ICollection<NoteEntity>> SortNotesByCategory(Guid houseId, int? noteCategory)
        {
            return await _context.Notes
                            .Include(mp => mp.User)
                                .ThenInclude(u => u.HouseUsers)
                                    .ThenInclude(hu => hu.House)
                                .Where(mp => mp.User.HouseUsers.Any(hu => hu.HouseId == houseId)
                                    && (noteCategory == null || (int)mp.Category == noteCategory))
                                .ToListAsync();
        }

        public async Task<ICollection<NoteholderEntity>> GetNoteholders(Guid houseId)
        {
            return await _context.Noteholders
                            .Include(nh => nh.NoteholderNotes)
                                .ThenInclude(nhn => nhn.Note)
                            .Include(nh => nh.HouseNoteholders)
                                .ThenInclude(hn => hn.House)
                            .Where(nh => nh.HouseNoteholders.Any(hn => hn.HouseId == houseId))
                            .ToListAsync();
        }

        public async Task<NoteholderEntity> GetFullNoteholderById(Guid noteholderId, Guid houseId)
        {
            return await _context.Noteholders
                        .Include(nh => nh.HouseNoteholders)
                        .Where(nh => nh.HouseNoteholders.Any(hn => hn.HouseId == houseId && hn.NoteholderId == noteholderId))
                        .SingleOrDefaultAsync();
        }
        public async Task<NoteholderEntity> GetNoteholderById(Guid noteholderId)
        {
            return await _context.Noteholders.Where(n => n.Id == noteholderId).FirstOrDefaultAsync();
        }

        public async Task<NoteEntity> GetNoteById(Guid noteId)
        {
            return await _context.Notes.Where(n => n.Id == noteId).FirstOrDefaultAsync();
        }

        public async Task<ICollection<NoteEntity>> GetNotesForNoteholder(Guid noteholderId)
        {
            return await _context.Notes
                      .Where(n => n.NoteholderNotes
                      .Any(nh => nh.NoteholderId == noteholderId))
                      .ToListAsync();
        }

        public async Task<ICollection<NoteEntity>> GetNewOrUpdatedNotes(Guid houseId)
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

        public async Task<ICollection<NoteholderEntity>> GetNewOrUpdatedNoteholders(Guid houseId)
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
