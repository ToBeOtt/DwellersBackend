namespace Dwellers.Chat.Contracts.Requests
{
    public record SaveMessageRequest (
        string Message,
        string DwellerId,
        Guid ConversationId);
}
