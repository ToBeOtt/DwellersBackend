using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Contracts.Requests
{
    public record RegisterHouseRequest(
        string Name,
        string? Description,
        string Email,
        IFormFile? HousePhoto
        );
}
