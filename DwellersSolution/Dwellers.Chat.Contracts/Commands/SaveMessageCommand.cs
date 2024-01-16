namespace Dwellers.Chat.Contracts.Commands
{
    public record SaveMessageCommand(
        string MessageText, 
        string DwellerId, 
        Guid ConversationId);
}
