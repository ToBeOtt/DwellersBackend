using Microsoft.AspNetCore.Http;

namespace Dwellers.DwellerCore.Contracts.Commands
{
    public record SetDwellerProfilePhotoCommand(
          string DwellerId,
          IFormFile DwellerPhoto);
}
