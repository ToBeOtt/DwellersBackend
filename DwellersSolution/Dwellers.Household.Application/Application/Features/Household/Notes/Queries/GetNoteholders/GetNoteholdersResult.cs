using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders
{
    public record GetNoteholdersResult(
         ICollection<Noteholder> Noteholders);
}
