namespace Dwellers.Notes.Contracts.Requests
{
    public record AddNoteholderRequest(
        string? Category,
        string? NoteholderScope,
        string Name
        );
}
