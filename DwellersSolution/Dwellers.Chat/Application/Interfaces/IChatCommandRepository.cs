using Dwellers.Common.DAL.Models.DwellerChat;

namespace Dwellers.Chat.Application.Interfaces
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(DwellerMessageEntity message);
        Task<bool> PersistConversation(DwellerConversationEntity conversation);
        Task<bool> PersistHouseConversation(HouseConversationEntity houseConversation);
    }
}
