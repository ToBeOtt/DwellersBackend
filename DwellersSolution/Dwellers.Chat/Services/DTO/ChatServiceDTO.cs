using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Data.Models.DwellerChat;

namespace Dwellers.Chat.Services.DTO
{
    public class ChatServiceDTO
    {
        public record GetConversationsDTO(
           ICollection<DwellerMessageEntity> ConversationMessages,
           Guid ConversationId);
    }
}
