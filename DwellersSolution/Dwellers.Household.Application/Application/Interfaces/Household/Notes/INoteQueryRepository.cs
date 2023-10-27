using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Application.Interfaces.Household.Meetings
{
    public interface INoteQueryRepository
    {
        Task<ICollection<Note>> GetNotes(Guid houseId);
        Task<ICollection<Note>> SortNotesByCategory(Guid houseId, int? noteCategory);
        Task<ICollection<Noteholder>> GetNoteholders(Guid houseId);
        Task<Noteholder> GetFullNoteholderById(Guid noteholderId, Guid HouseId);
        Task<Noteholder> GetNoteholderById(Guid noteholderId);
        Task<Note> GetNoteById(Guid NoteId);
        Task <ICollection<Note>> GetNotesForNoteholder (Guid noteholderId);

        Task<ICollection<Note>> GetNewOrUpdatedNotes(Guid HouseId);
        Task<ICollection<Noteholder>> GetNewOrUpdatedNoteholders(Guid HouseId);
        
    }
}
