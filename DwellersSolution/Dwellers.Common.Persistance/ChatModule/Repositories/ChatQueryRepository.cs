using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Persistance.ChatModule.Repositories
{
    public class ChatQueryRepository : IChatQueryRepository
    {
        private readonly DwellerDbContext _context;

        public ChatQueryRepository(
            DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<DwellerConversationEntity> GetConversation(Guid conversationId)
        {
            return 
                await _context.DwellerConversations
                .Where(c => c.Id == conversationId)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DwellerMessageEntity>> GetConversationMessages(Guid conversationId)
        {
            return 
                await _context.DwellerMessages
                .Where(dm => dm.ConversationId == conversationId)
                .ToListAsync();
        }

        public async Task<DwellerConversationEntity> GetHouseholdConversation(Guid dwellingId)
        {
            return 
                await _context.DwellerConversations
                .Include(dc => dc.DwellingConversationEntity)
                .Where(dc => dc.DwellingConversationEntity
                    .Any(hc => hc.DwellingId == dwellingId))
                    .SingleOrDefaultAsync();
        } 
    }
}