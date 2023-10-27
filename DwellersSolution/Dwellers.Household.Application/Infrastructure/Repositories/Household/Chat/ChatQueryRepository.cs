using Dwellers.Household.Application.Interfaces.Household.Chat;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.ValueObjects;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Infrastructure.Repositories.Household.Chat
{
    public class ChatQueryRepository : IChatQueryRepository
    {
        
        private readonly HouseholdDbContext _context;
        private readonly ILogger<ChatQueryRepository> _logger;

        public ChatQueryRepository(
            HouseholdDbContext context,
            ILogger<ChatQueryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DwellerConversation> GetConversation(Guid conversationId)
        {
            return await _context.DwellerConversations.Where(c => c.Id == conversationId).SingleOrDefaultAsync();
        }

        public async Task<ICollection<DwellerMessage>> GetConversationMessages(Guid conversationId)
        {
            return await _context.DwellerMessages
                .Where(dm => dm.Conversation.Id == conversationId)
                .Include(dm => dm.User)
                .ToListAsync();
        }

        public async Task<DwellerConversation> GetHouseholdConversation(Guid houseId)
        {
            return await _context.DwellerConversations
                .Include(dc => dc.HouseConversations)
                .Where(dc => dc.HouseConversations
                    .Any(hc => hc.HouseId == houseId))
                    .SingleOrDefaultAsync();
        }
    }
}