using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.NotesModule.Repositories
{
    public class NoteCommandRepository : INoteCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<NoteCommandRepository> _logger;

        public NoteCommandRepository(
            DwellerDbContext context,
            ILogger<NoteCommandRepository> logger)
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
        public async Task<bool> AddNoteholder(NoteholderEntity noteholder)
        {
            await _context.Noteholders.AddAsync(noteholder);
            int result = await SaveActions();
            return result > 0;
        }
        public async Task<bool> AddNote(NoteEntity note)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Notes.AddAsync(note);
                    await SaveActions();
                    transaction.Commit(); 
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error adding a note.");
                    transaction.Rollback(); 
                    return false;
                }
            }
        }

        public async Task<bool> AddHouseNoteholder(HouseNoteholderEntity HouseNoteholder)
        {
            await _context.HouseNoteholders.AddAsync(HouseNoteholder);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> RemoveNote(NoteEntity Note)
        {
            _context.Notes.Remove(Note);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> RemoveNoteholder(NoteholderEntity Noteholder)
        {
            _context.Noteholders.Remove(Noteholder);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> AddNoteholderNote(NoteholderNotesEntity noteholderNotes)
        {
            await _context.NoteholderNotes.AddAsync(noteholderNotes);
            int result = await SaveActions();
            return result > 0;
        }
    }
}
