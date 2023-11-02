using Microsoft.AspNetCore.Http;

namespace Dwellers.Offerings.Contracts.Commands
{
    public record AddDwellerItemCommand(
           string Name,
           string Desc,
           string ItemScope,
           IFormFile ItemPhoto,
           Guid HouseId
           );

    public record RemoveDwellerItemCommand(
          Guid ItemId
          );

}
