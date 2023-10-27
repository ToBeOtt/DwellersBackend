using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Application.Interfaces.Household.Meetings
{
    public interface INoteCommandRepository
    {
        Task<bool> AddNoteholder(Noteholder noteholder);
        Task<bool> AddNoteholderNote(NoteholderNotes noteholderNotes);
        Task<bool> AddNote(Note note);
        Task<bool> AddHouseNoteholder(HouseNoteholder HouseNoteholder);
        Task<bool> RemoveNote(Note NoteId);
        Task<bool> RemoveNoteholder(Noteholder NoteholderId);
    }
}
