using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Domain.Entities.Notes;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dwellers.Household.Infrastructure.Repositories.Household.Meetings
{
    public class NoteCommandRepository : INoteCommandRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly ILogger<NoteCommandRepository> _logger;

        public NoteCommandRepository(
            HouseholdDbContext context,
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
        public async Task<bool> AddNoteholder(Noteholder noteholder)
        {
            await _context.Noteholders.AddAsync(noteholder);
            int result = await SaveActions();
            return result > 0;
        }
        public async Task<bool> AddNote(Note note)
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

        public async Task<bool> AddHouseNoteholder(HouseNoteholder HouseNoteholder)
        {
            await _context.HouseNoteholders.AddAsync(HouseNoteholder);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> RemoveNote(Note Note)
        {
            _context.Notes.Remove(Note);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> RemoveNoteholder(Noteholder Noteholder)
        {
            _context.Noteholders.Remove(Noteholder);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> AddNoteholderNote(NoteholderNotes noteholderNotes)
        {
            await _context.NoteholderNotes.AddAsync(noteholderNotes);
            int result = await SaveActions();
            return result > 0;
        }
    }
}
