using Dwellers.Common.Data.Models.DwellerChat;

namespace Dwellers.Common.Persistance.ChatModule.Interfaces
{
    public interface IChatQueryRepository
    {
        Task<DwellerConversationEntity> GetConversation(Guid conversationId);
        Task<DwellerConversationEntity> GetHouseholdConversation(Guid houseId);
        Task<ICollection<DwellerMessageEntity>> GetConversationMessages(Guid conversationId);
    }
}
