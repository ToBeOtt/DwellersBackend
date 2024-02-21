using Dwellers.Chat.Domain.Entities;

namespace Dwellers.Common.Application.Interfaces.Chats
{
    public interface IChatCommandRepository
    {
        Task<bool> PersistMessage(DwellerMessage message);
        Task<bool> PersistConversation(DwellerConversation conversation);
        Task<bool> PersistMembersInConversation(List<MemberInConversation> listOfMembers);
    }
}
