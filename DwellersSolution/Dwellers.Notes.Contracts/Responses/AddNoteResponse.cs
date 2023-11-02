using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Notes.Contracts.Responses
{
    public record AddNoteResponse(
        NoteEntity Note
        );
}
