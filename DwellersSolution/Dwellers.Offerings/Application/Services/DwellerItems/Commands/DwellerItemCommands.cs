using Microsoft.AspNetCore.Http;

namespace Dwellers.Offerings.Application.Services.DwellerItems.Commands
{
    public record AddDwellerItemCommand(
           string Name,
           string Desc,
           string ItemScope,
           IFormFile ItemPhoto,
           Guid HouseId
           );
}
