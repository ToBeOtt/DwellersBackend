using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Contracts.Requests.Household.Notes
{
    public record AddNoteholderRequest(
        string? Category,
        string? NoteholderScope,
        string Name
        );
}
