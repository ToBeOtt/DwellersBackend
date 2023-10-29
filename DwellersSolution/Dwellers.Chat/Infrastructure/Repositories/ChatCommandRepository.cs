using Dwellers.Chat.Application.Interfaces;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Infrastructure.Repositories
{
    public class ChatCommandRepository : IChatCommandRepository
    {
        private readonly ChatDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            ChatDbContext context,
            ILogger<ChatCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        private async Task<int> SaveActions()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
        }
        public async Task<bool> PersistMessage(DwellerMessage message)
        {
            _context.DwellerMessages.Add(message);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> PersistConversation(DwellerConversation conversation)
        {
            _context.DwellerConversations.Add(conversation);
            int result = await SaveActions();
            return result > 0;
        }
        public async Task<bool> PersistHouseConversation(HouseConversation houseConversation)
        {
            _context.HouseConversations.Add(houseConversation);
            int result = await SaveActions();
            return result > 0;
        }
    }
}