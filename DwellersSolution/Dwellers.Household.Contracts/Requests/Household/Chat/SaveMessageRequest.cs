namespace Dwellers.Household.Contracts.Requests.Household.Chat
{
    public record SaveMessageRequest (
        string Message,
        Guid ConversationId);
}
