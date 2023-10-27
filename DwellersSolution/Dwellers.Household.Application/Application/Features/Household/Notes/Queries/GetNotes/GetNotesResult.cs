using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNotes
{
    public record GetNotesResult(
         ICollection<Note> Notes);

}
