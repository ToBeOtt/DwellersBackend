using Dwellers.Chat.Application.Interfaces;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Infrastructure.Repositories
{
    public class ChatQueryRepository : IChatQueryRepository
    {  
        private readonly ChatDbContext _context;
        private readonly ILogger<ChatQueryRepository> _logger;

        public ChatQueryRepository(
            ChatDbContext context,
            ILogger<ChatQueryRepository> logger)
        {
            _context = context;
            _logger = logger;
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
                .Where(dm => dm.Conversation.Id == conversationId)
                .ToListAsync();
        }

        public async Task<DwellerConversation> GetHouseholdConversation(Guid houseId)
        {
            return 
                await _context.DwellerConversations
                .Include(dc => dc.HouseConversations)
                .Where(dc => dc.HouseConversations
                    .Any(hc => hc.HouseId == houseId))
                    .SingleOrDefaultAsync();
        } 
    }
}