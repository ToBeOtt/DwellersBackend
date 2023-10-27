using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Contracts.Responses.Household.Notes
{
    public record GetNoteholderResponse(
        Noteholder Noteholder,
        ICollection<Note> Notes);
}
