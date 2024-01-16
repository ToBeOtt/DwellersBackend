using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Data.Models.DwellerChat;

namespace Dwellers.Common.Persistance.ChatModule.Interfaces
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(Message message);
        Task<bool> PersistConversation(Conversation conversation);
        Task<bool> PersistHouseConversation(DwellingConversationEntity houseConversation);
    }
}
