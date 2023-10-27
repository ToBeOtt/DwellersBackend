using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.RemoveNote
{
    public record RemoveNoteCommand(
      Guid NoteId) : IRequest<RemoveNoteResult>;
}

