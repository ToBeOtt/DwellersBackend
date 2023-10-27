using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Application.Interfaces.Household.Chat
{
    public interface IChatQueryRepository
    {
        Task<DwellerConversation> GetConversation(Guid conversationId);
        Task<DwellerConversation> GetHouseholdConversation(Guid houseId);
        Task <ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId);
    }
}
