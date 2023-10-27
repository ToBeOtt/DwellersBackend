using Dwellers.Household.Application.Interfaces.Household.Chat;
using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.ValueObjects;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Infrastructure.Repositories.Household.Chat
{
    public class ChatCommandRepository : IChatCommandRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            HouseholdDbContext context,
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
