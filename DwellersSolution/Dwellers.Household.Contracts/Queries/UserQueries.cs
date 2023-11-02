namespace Dwellers.Household.Contracts.Queries
{
    public record FetchUserDataQuery(
         string UserId,
         Guid HouseId
        );
}
