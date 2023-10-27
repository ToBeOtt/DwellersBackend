using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Contracts.Responses.Household.Dashboard
{
    public record GetDashboardNotesResponse(
     ICollection<Note> Notes,
     ICollection<Noteholder> Noteholders);
}
