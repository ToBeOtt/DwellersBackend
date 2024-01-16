namespace Dwellers.Chat.Contracts.Commands
{
    public record EstablishConversationCommand(
        Guid DwellingId, 
        string DwellingName
        );
}
