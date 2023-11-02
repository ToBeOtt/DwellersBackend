namespace Dwellers.Chat.Contracts.Requests
{
    public record SaveMessageRequest (
        string Message,
        Guid ConversationId);
}
