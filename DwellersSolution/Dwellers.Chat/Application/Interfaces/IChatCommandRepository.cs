using Dwellers.Chat.Domain.Entities;

namespace Dwellers.Chat.Application.Interfaces
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(DwellerMessage message);
        Task<bool> PersistConversation(DwellerConversation conversation);
        Task<bool> PersistHouseConversation(HouseConversation houseConversation);
    }
}
