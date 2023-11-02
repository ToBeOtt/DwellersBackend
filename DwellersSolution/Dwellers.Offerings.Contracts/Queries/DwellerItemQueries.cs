namespace Dwellers.Offerings.Contracts.Queries
{
    public record GetDwellerItemQuery(
          Guid ItemId
          );

    public record GetAllDwellerItemsQuery(
          Guid HouseId
          );
}