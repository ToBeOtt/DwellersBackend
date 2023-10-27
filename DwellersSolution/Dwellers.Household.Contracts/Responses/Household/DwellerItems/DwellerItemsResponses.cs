using Dwellers.Household.Domain.Entities.DwellerItems;

namespace Dwellers.Household.Contracts.Responses.Household.DwellerItems
{
    public record AddDwellerItemResponse(
        bool Success);
    public record RemoveDwellerItemResponse(
        bool Success);

    public record GetDwellerItemResponse(
       DwellerItem DwellerItem);
    public record GetAllDwellerItemsResponse(
       ICollection<DwellerItem> DwellerItems);

}
