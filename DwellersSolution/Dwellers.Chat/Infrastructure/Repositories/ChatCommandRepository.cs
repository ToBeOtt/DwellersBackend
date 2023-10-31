using Dwellers.Chat.Application.Interfaces;
using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerChat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Infrastructure.Repositories
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
        public async Task<bool> PersistHouseConversation(HouseConversationEntity houseConversation)
        {
            _context.HouseConversations.AddAsync(houseConversation);
            int result = await SaveActions();
            return result > 0;
        }
    }
}