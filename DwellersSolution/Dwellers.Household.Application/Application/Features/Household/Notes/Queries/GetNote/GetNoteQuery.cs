using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNote
{
    public record GetNoteQuery(
       Guid NoteId) : IRequest<GetNoteResult>;
}
