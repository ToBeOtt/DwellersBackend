using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Application.Interfaces.Household.Chat
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(DwellerMessage message);
        Task<bool> PersistConversation(DwellerConversation conversation);
        Task<bool> PersistHouseConversation(HouseConversation houseConversation);
    }
}
