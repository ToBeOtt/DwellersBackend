using Dwellers.Common.Data.Models.DwellerChat;

namespace Dwellers.Common.Persistance.ChatModule.Interfaces
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(DwellerMessageEntity message);
        Task<bool> PersistConversation(DwellerConversationEntity conversation);
        Task<bool> PersistHouseConversation(DwellingConversationEntity houseConversation);
    }
}
