namespace Dwellers.Offerings.Contracts.Requests
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
}
