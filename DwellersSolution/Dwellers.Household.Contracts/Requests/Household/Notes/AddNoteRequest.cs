using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Contracts.Requests.Household.Notes
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

