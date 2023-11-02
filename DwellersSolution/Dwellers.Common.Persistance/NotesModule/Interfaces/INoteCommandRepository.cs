using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Persistance.NotesModule.Interfaces
{
    public interface INoteCommandRepository
    {
        Task<bool> AddNoteholder(NoteholderEntity noteholder);
        Task<bool> AddNoteholderNote(NoteholderNotesEntity noteholderNotes);
        Task<bool> AddNote(NoteEntity note);
        Task<bool> AddHouseNoteholder(HouseNoteholderEntity HouseNoteholder);
        Task<bool> RemoveNote(NoteEntity NoteId);
        Task<bool> RemoveNoteholder(NoteholderEntity NoteholderId);
    }
}
