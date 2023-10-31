using Dwellers.Common.DAL.Models.DwellerChat;

namespace Dwellers.Chat.Application.Interfaces
{
    public interface IChatQueryRepository
    {
        Task<DwellerConversationEntity> GetConversation(Guid conversationId);
        Task<DwellerConversationEntity> GetHouseholdConversation(Guid houseId);
        Task<ICollection<DwellerMessageEntity>> GetConversationMessages(Guid conversationId);
    }
}
