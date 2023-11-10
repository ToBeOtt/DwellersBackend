using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Persistance.NotesModule.Interfaces
{
    public interface INoteCommandRepository
    {
        Task<bool> AddNote(NoteEntity note);
        Task<bool> RemoveNote(NoteEntity NoteId);
    }
}
