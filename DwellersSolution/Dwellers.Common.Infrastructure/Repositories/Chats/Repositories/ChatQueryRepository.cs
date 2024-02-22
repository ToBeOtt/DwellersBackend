using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.Repositories.Chats.Repositories
{
    public class ChatQueryRepository : IChatQueryRepository
    {
        private readonly DwellerDbContext _context;

        public ChatQueryRepository(
            DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<DwellerConversation> GetConversation(Guid conversationId)
        {
            return
                await _context.DwellerConversations
                .Where(c => c.Id == conversationId)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId)
        {
            return
                await _context.DwellerMessages
                .Where(m => m.Id == conversationId)
                .ToListAsync();
        }

        public async Task<DwellerConversation> GetDwellingConversation(Guid dwellingId)
        {
            return
                await _context.DwellerConversations
                .Where(hc => hc.Id == dwellingId)
                    .SingleOrDefaultAsync();
        }

        Task<DwellerConversation> IChatQueryRepository.GetConversation(Guid conversationId)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<DwellerMessage>> IChatQueryRepository.GetConversationMessages(Guid conversationId)
        {
            throw new NotImplementedException();
        }

        Task<DwellerConversation> IChatQueryRepository.GetHouseholdConversation(Guid houseId)
        {
            throw new NotImplementedException();
        }
    }
}