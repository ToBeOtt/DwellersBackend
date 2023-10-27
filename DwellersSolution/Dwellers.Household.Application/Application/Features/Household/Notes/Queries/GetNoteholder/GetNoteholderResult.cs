using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholder
{
    public record GetNoteholderResult(
        Noteholder Noteholder,
        ICollection<Note>? Notes);
}
