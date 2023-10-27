using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNotes
{
    public record GetNotesQuery(
       Guid HouseId,
       int? NoteCategory
        ) : IRequest<GetNotesResult>;
}
