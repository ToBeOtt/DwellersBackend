using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.ChatModule.Repositories
{
    public class ChatCommandRepository : IChatCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            DwellerDbContext context,
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
        public async Task<bool> PersistMessage(DwellerMessageEntity message)
        {
            _context.DwellerMessages.AddAsync(message);
            int result = await SaveActions();
            return result > 0;
        }

        public async Task<bool> PersistConversation(DwellerConversationEntity conversation)
        {
            _context.DwellerConversations.AddAsync(conversation);
            int result = await SaveActions();
            return result > 0;
        }
        public async Task<bool> PersistHouseConversation(DwellingConversationEntity houseConversation)
        {
            _context.DwellingConversations.AddAsync(houseConversation);
            int result = await SaveActions();
            return result > 0;
        }
    }
}