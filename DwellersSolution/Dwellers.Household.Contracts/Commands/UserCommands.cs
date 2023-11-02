using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Contracts.Commands
{
    public record UpdateUserCommand(
       string UserId,
       IFormFile ProfilePhoto);
}
