using Microsoft.AspNetCore.Http;

namespace Dwellers.Authentication.Contracts.Requests
{
    public record RegisterHouseRequest(
        string Name,
        string? Description,
        string Email,
        IFormFile? HousePhoto
        );
}
