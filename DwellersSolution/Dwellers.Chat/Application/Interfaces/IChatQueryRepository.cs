using Dwellers.Chat.Domain.Entities;

namespace Dwellers.Chat.Application.Interfaces
{
    public interface IChatQueryRepository
    {
        Task<DwellerConversation> GetConversation(Guid conversationId);
        Task<DwellerConversation> GetHouseholdConversation(Guid houseId);
        Task<ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId);
    }
}
