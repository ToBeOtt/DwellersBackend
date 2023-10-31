
namespace Dwellers.Notes.Contracts.Requests
{
    public record AddNoteRequest(
        string Name,
        string Desc,
        string? NoteStatus,
        string? NotePriority,
        string? NoteScope,
        string? Category,
        Guid? NoteholderId
        );
}

