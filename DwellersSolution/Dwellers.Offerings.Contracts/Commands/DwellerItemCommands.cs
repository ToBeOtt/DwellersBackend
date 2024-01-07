using Microsoft.AspNetCore.Http;

namespace Dwellers.Offerings.Contracts.Commands
{
    public record AddDwellerItemCommand(
           string Name,
           string Desc,
           string ItemScope,
           IFormFile ItemPhoto,
           Guid DwellingId
           );

    public record RemoveDwellerItemCommand(
          Guid ItemId
          );

}
