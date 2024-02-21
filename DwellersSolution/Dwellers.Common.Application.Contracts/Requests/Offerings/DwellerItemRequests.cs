namespace Dwellers.Common.Application.Contracts.Requests.Offerings
{
    public record AddDwellerItemRequest(
        string Name,
        string Description,
        string ItemScope);

    public record RemoveDwellerItemRequest(
       Guid ItemId);

    public record GetDwellerItemRequest();

    public record GetAllDwellerItemsRequest();
}

