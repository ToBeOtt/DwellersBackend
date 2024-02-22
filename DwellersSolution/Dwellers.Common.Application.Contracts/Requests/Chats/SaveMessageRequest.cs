namespace Dwellers.Common.Application.Contracts.Requests.Chats
{
    public record SaveMessageRequest(
        string Message,
        string DwellerId,
        Guid ConversationId);
}
