namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders
{
    public record GetNoteholdersResult(
         ICollection<NoteholderEntity> Noteholders);
}
