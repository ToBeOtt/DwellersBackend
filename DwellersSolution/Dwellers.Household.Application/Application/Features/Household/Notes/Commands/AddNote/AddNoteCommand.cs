using Dwellers.Household.Domain.ValueObjects;
using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.AddNote
{
    public record AddNoteCommand(
        string Name,
        string Desc,
        string? NoteStatus,
        string? NotePriority,
        string? NoteScope,
        string? Category,
        Guid? NoteholderId,
        string UserId,
        Guid HouseId) : IRequest<AddNoteResult>;
}
