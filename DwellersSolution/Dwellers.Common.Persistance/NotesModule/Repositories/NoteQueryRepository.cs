using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.NotesModule.Repositories
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

        //public async Task<ICollection<NoteEntity>> SortNotesByCategory(Guid houseId, int? noteCategory)
        //{
        //    return await _context.Notes
        //                    .Include(mp => mp.User)
        //                        .ThenInclude(u => u.HouseUsers)
        //                            .ThenInclude(hu => hu.House)
        //                        .Where(mp => mp.User.HouseUsers.Any(hu => hu.HouseId == houseId)
        //                            && (noteCategory == null || (int)mp.Category == noteCategory))
        //                        .ToListAsync();
        //}

        public async Task<NoteEntity> GetNoteById(Guid noteId)
        {
            return await _context.Notes.Where(n => n.Id == noteId).FirstOrDefaultAsync();
        }

        Task<ICollection<NoteEntity>> INoteQueryRepository.SortNotesByCategory(Guid houseId, int? noteCategory)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<NoteEntity>> INoteQueryRepository.GetNotesForNoteholder(Guid noteholderId)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<NoteEntity>> INoteQueryRepository.GetNewOrUpdatedNotes(Guid HouseId)
        {
            throw new NotImplementedException();
        }
    }
}
